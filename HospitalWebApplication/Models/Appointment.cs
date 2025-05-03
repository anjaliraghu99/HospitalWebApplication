using System.ComponentModel.DataAnnotations;

namespace HospitalWebApplication.Models
{
    public class Appointment
    {
        [Key]
        public string AppointmentId { get; set; }

        public string PatientId { get; set; }
        public string PatientName { get; set; }
        public string DoctorId { get; set; }
        public Doctor DoctorName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public string BillId { get; set; }
    }
}