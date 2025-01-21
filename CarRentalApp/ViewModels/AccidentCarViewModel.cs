using CarRentalApp.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace CarRentalApp.ViewModels
{
    [Keyless]
    public class AccidentCarViewModel
    {
        public int AccidentId { get; set; }
        [DisplayName("رقم السيارة")]
        public int CarId { get; set; }
        [DisplayName("تأريخ الحادث")]
        public DateTime AccidentDate { get; set; }
        [ValidateNever]
        [DisplayName("تفاصيل الحادث")]
       
        public string Description { get; set; }
        [DisplayName("رقم الحادث")]
        public string AccidentNumber { get; set; }
        [ValidateNever]
        public int AccidentStatus { get; set; }
        [ValidateNever]
        public int CompanyId { get; set; }
        [ValidateNever]
        public int TrafficreportId { get; set; }
        [ValidateNever]
        public string TrafficreportName { get; set; }
        [ValidateNever]
        public Trafficreport Trafficreport { get; set; }
        [ValidateNever]
        public List<Trafficreport> trafficreports { get; set; }

        [ValidateNever]
        [DisplayName("إسم شركة التأمين")]
        public string CompanyNameAr { get; set; }
        [ValidateNever]
        public Company company { get; set; }
        [ValidateNever]
        public List<Company> companies { get; set; }
        public int BranchId { get; set; }
        [DisplayName("نسبة التحمل")]
        public decimal Percentage { get; set; }
        [DisplayName("رقم اللوحة")]
        [ValidateNever]

        public string PlateNumber { get; set; }
        [DisplayName("رقم الهيكل")]
        public string? ChassisNumber { get; set; }
        [DisplayName("إسم السائق")]
        public string? DriverName { get; set; }
        [DisplayName(" رخصة السائق")]
        public string? DriveLicence { get; set; }
        [DisplayName(" رقم الهوية")]
        public string? DriverIdentity { get; set; }
        [DisplayName("إسم السائق الاخر")]
        public string? DriverNameOther { get; set; }
       [DisplayName("رخصة السائق الاخر")]
        public string? DriveLicenceOther { get; set; }
        [DisplayName(" رقم الهوية الاخر")]
        public string? DriverIdentityOther { get; set; }
        [DisplayName(" شركة تأمين الاخر")]
        public string? DriverCompanyOther { get; set; }
        [ValidateNever]
        
        public Modeel modeel { get; set; }
        [ValidateNever]
        public List<Modeel> modeels { get; set; }
        [ValidateNever]
        [DisplayName("الملفات المرفقة")]
        public IFormFile Photo { get; set; }
        
    }
}
