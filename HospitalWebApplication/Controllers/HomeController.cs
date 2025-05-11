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
using Newtonsoft.Json;
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
        public async Task<IActionResult> Login(User user)
        {
            if (user != null)
            {
                // Validate user credentials
                var data = _dataDbContext.Users
                    .FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);

                if (data != null) // Check if user exists in the database
                {
                    // Create an object to store session data
                    var sessionData = new
                    {
                        Email = data.Email ?? "",
                        FirstName = data.FirstName ?? "",
                        LastName = data.LastName ?? "",
                        PhoneNumber = data.phoneNumber?.ToString() ?? ""
                    };

                    // Serialize the object to a JSON string and store it in session
                    HttpContext.Session.SetString("UserSessionData", JsonConvert.SerializeObject(sessionData));

                    // Redirect to the Index page (authenticated page)
                    return RedirectToAction("Index");
                }
                else
                {
                    // Optionally, you can add an error message here or redirect to a login error page
                    TempData["ErrorMessage"] = "Invalid credentials!";
                    return RedirectToAction("Login");
                }
            }

            // If the user object is null, redirect to the login page
            return RedirectToAction("Login");
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
