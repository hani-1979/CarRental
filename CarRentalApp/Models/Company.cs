using System.ComponentModel.DataAnnotations;

namespace CarRentalApp.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        public string CompanyNameAr { get; set; }
        public string CompanyNameEn { get; set; }
    }
}
