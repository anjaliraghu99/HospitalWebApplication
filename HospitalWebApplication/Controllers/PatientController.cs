using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using HospitalWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using static System.Reflection.Metadata.BlobBuilder;



namespace HospitalWebApplication.Controllers
{
    public class PatientController: Controller
    {

        private readonly DataDbContext _dataDbContext;

        //public HomeController(ILogger<HomeController> logger)

        public PatientController(DataDbContext dataDbContext)
        {
            _dataDbContext = dataDbContext;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        public async Task<IActionResult> RegisterUser(Patient patient)
        {
            var data = _dataDbContext.Patients.FirstOrDefault(x => x.PatientId == patient.PatientId);
            if (data == null)
            {
                var userdata = new Patient
                {
                    PatientId = Guid.NewGuid().ToString(),
                    FirstName = "",
                    LastName = patient.LastName,
                    DateOfBirth = patient.DateOfBirth?.ToUniversalTime(),
                    Gender = patient.Gender,
                    Phone = patient.Phone,
                    Address = patient.Address,
                    CreatedDate = patient.CreatedDate,
                    BillFileId = patient.BillFileId,


                };

                _dataDbContext.Patients.Add(userdata);
                _dataDbContext.SaveChanges();

                return RedirectToAction("Login");

            }
            return View(patient);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
