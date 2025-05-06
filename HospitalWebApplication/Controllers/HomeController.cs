using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using HospitalWebApplication.Models;
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
            return View();
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
        [HttpGet]
        public IActionResult Resigter()
        {
            return View();
        }

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


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
