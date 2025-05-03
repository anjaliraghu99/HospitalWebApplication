using HospitalWebApplication.Models;
using System.ComponentModel.DataAnnotations;

namespace HospitalWebApplication.Models
{
    public class LOV
    {
        [Key]
        public string LOVId { get; set; } 
        public string LOVType { get; set; }
        public string Name { get; set; }
        public string LOVCode { get; set; }

    }
}

//LOV Types 



