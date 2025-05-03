using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace HospitalWebApplication.Models
{
    public class DataDbContext:DbContext
    {
        public DataDbContext(DbContextOptions options) : base(options) { 
        
        }
        public DbSet<User> Users { get; set; } // wii be used for login 
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Bill> Bill { get; set; }
        public DbSet<Files> Files { get; set; }
        public DbSet<LOV> Lov { get; set; }

    }

}
