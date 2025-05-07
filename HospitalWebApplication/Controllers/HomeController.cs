using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using HospitalWebApplication.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using static System.Reflection.Metadata.BlobBuilder;

namespace HospitalWebApplication.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly DataDbContext _dataDbContext;

        //public HomeController(ILogger<HomeController> logger)
      
        public HomeController(DataDbContext dataDbContext)
        {
            _dataDbContext = dataDbContext;
        }

        public IActionResult Index()
        {
            var data = _dataDbContext.Appointments.ToList();
            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public async Task<Boolean> Login(User user)
        {
            if (user!=null)
            {
                var data = _dataDbContext.Users.FirstOrDefault(x=>x.Email == user.Email && x.Password==user.Password);
                return true;
            }
            return false;
          
          
        }

        public IActionResult Logout()
        {
             HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
             return View();
        }

        [HttpGet]
        public IActionResult Resigter()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            var data = _dataDbContext.Users.FirstOrDefault(x => x.Email == user.Email);
            if(data!=null)
            {
                var userdata = new User
                {
                    UserId= Guid.NewGuid().ToString(),
                    UserRoleId = "2",
                    Password=user.Password,
                    UserRoleCode=user.UserRoleCode


                };

                _dataDbContext.Users.Add(userdata);
                _dataDbContext.SaveChanges();
                return RedirectToAction("Login");

            }
            return View(user);
        }


        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        [Authorize]

        public IActionResult SecurePage()
        {
            ViewBag.Name = HttpContext.User.Identity.Name;

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
