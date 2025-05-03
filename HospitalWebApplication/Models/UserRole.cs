using System.ComponentModel.DataAnnotations;

namespace HospitalWebApplication.Models
{
    public class UserRole
    {
        [Key]
        public string UserRoleId { get; set; }
        public string? RoleName { get; set; }
        public string? RoleNameCode { get; set; }
        public string? RoleDescription { get; set; }
    }
}