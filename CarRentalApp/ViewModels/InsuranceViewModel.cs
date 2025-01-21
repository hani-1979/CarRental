using CarRentalApp.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalApp.ViewModels
{
    [Keyless]
    public class InsuranceViewModel
    {
        [Key]
        
        public int InsuranceId { get; set; }
        [DisplayName("إسم شركة التأمين")]
        public int CompanyId { get; set; }
        [DisplayName("إسم شركة التأمين")]
        [ValidateNever]
        public string CompanyNameAr { get; set; }
        [ValidateNever]
        public List<Company> companies { get; set; }
        [ValidateNever]
        [DisplayName("رقم اللوحة")]
        public string PlateNumber { get; set; }
        [ValidateNever]
        public Company company  { get; set; }
        public int CarId { get; set; }
        [DisplayName("رقم الوثيقة")]
        public string PolicyNumber { get; set; }
        [DisplayName("تأريخ بداية الوثيقة")]
        public DateTime BDPolicyNumber { get; set; }
        [DisplayName("تأريخ نهاية الوثيقة")]
        public DateTime EDPolicyNumber { get; set; }
        [ValidateNever]
        [DisplayName("الملفات المرفقة")]
        public IFormFile Photo { get; set; }


    }
}
