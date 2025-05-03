using System.ComponentModel.DataAnnotations;

namespace HospitalWebApplication.Models
{
    public class Doctor
    {
        [Key]
        public string DoctorId { get; set; }
        public string? FullName { get; set; }

        public string? specialization { get; set; }
        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? AvailabilitySchedule { get; set; }

    }
}