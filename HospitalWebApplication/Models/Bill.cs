using System.ComponentModel.DataAnnotations;

namespace HospitalWebApplication.Models
{
    public class Bill
    {
        [Key]
        public string BillId { get; set; }
        public string BillFileId { get; set; }
        public string AppointmentId { get; set; }
        public string TotalAmount { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}