using Microsoft.AspNetCore.Routing.Constraints;
using System.ComponentModel.DataAnnotations;

namespace HospitalWebApplication.Models
{
    public class Files
    {
        [Key]
        public string FileId { get; set; }

        public  string?  FileName  { get; set; }
        public byte[] FileContent { get; set; }
        public DateTime UploadedAt { get; set; } = DateTime.Now;

    }
}