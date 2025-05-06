using System.ComponentModel.DataAnnotations;

namespace HospitalWebApplication.Models
{
    public class User
    {
        [Key]
        public string UserId { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int phoneNumber { get; set; }

        public string? Password { get; set; }
        public string? UserRoleId { get; set; }
        public string? UserRoleCode  { get; set; }
    }
}