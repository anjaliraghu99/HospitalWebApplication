using System.ComponentModel.DataAnnotations;

namespace HospitalWebApplication.Models
{
    public class Patient
    {
        [Key]
        public string PatientId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? AppointmentId { get; set; }
        public DateTime? DateOfBirth { get; set; } 
        public string? Gender { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? BillFileId { get; set; } 
    }
}