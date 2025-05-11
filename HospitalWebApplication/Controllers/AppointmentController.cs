using HospitalWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalWebApplication.Controllers
{
    public class AppointmentController : Controller
    {

        private readonly DataDbContext _dbContext;

        public AppointmentController(DataDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task <IActionResult> NewAppointment( Appointment model)
        {
            if (model!=null)
            {
                var email = HttpContext.User.Identity.Name;

                var userdata = _dbContext.Users.FirstOrDefault(x => x.Email == email);

                var newmodel = new Appointment
                {
                    AppointmentId = Guid.NewGuid().ToString(),
                    AppointmentDate = model.AppointmentDate.ToUniversalTime(),
                    PatientId = model.PatientId ?? "",
                    PatientName = model.PatientName??"",
                    DoctorId = model.DoctorId ?? "D001",
                    Notes = model.Notes ?? "",
                    BillId = model.BillId ?? "",
                    Status = model.Status ?? "Created"

                };
                _dbContext.Appointments.Add(newmodel);
               await  _dbContext.SaveChangesAsync();

            }
            return RedirectToAction("Index", "Home");

        }

        public IActionResult NewAppointment()
        {
            ViewBag.DiseaseList = _dbContext.Lov.Where(x => x.LOVType == "DiseaseListCetagoties").ToList();

            return View();

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
