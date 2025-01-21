using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarRentalApp.Models
{
    public class Company
    {
        [Key]
        [DisplayName("رقم الشركة")]
        public int CompanyId { get; set; }
        [DisplayName("إسم شركة التأمين عربي")]

        public string CompanyNameAr { get; set; }
        [DisplayName("إسم شركة التأمين عربي")]
        public string CompanyNameEn { get; set; }
       
       


    }
}
