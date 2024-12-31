using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace CarRentalApp.Models
{
    public class Insurance
    {
        [Key]
        public int InsuranceId { get; set; }
        public int CompanyId { get; set; }
        [ValidateNever]
        public Company Company { get; set; }
        public int CarId { get; set; }
        public string PolicyNumber { get; set; }
        public DateTime BDPolicyNumber { get; set; }
        public DateTime EDPolicyNumber { get; set; }
        public string? Comment { get; set; }

        public string? PhothPath { get; set; }
        
        public ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();
    }
}
