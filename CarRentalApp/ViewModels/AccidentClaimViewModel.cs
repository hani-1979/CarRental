using CarRentalApp.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarRentalApp.ViewModels
{
    [Keyless]
    public class AccidentClaimViewModel
    {
        public int carClaimId { get; set; }
        public int CarId  { get; set; }
        [DisplayName(" رقم المطالبة")]
        public string carClaimNumber { get; set; }
        public int AccidentId { get; set; }
        [DisplayName(" مبلغ المطالبة")]
        public decimal ClaimAmount { get; set; }
        [ValidateNever]
        [DisplayName("رقم الحادث")]
        public string AccidentNumber { get; set; }
        [DisplayFormat(DataFormatString = "{0:P0}", ApplyFormatInEditMode = true)]
        
        [DisplayName(" نسبة التحمل")]
        public decimal Percentage { get; set; }
        [DisplayName(" تأريخ المطالبة")]
        public DateTime ClaimDate { get; set; }
        public int EstimationId { get; set; }
        [ValidateNever]
        [DisplayName("رقم التقدير")]
        public string EstimationNumber { get; set; }
        [DisplayName("رقم اللوحة")]
        [ValidateNever]
        public string PlateNumber { get; set; }
        [DisplayName("رقم الهيكل")]
        public string? ChassisNumber { get; set; }
        public int CompanyId { get; set; }
        [ValidateNever]
        [DisplayName("إسم الشركة")]
        public string CompanyNameAr { get; set; }
        [ValidateNever]
        public List<Company> companies { get; set; }
        [ValidateNever]
        public Company company { get; set; }
        public int BranchId { get; set; }
        [ValidateNever]
        public List<Accident> accident { get; set; }
        [ValidateNever]
        public List<carClaim> carClaim { get; set; }
        public int StatusCode { get; set; }
        [DisplayName("الملفات المرفقة")]
        [ValidateNever]
        public IFormFile Photo { get; set; }
        [DisplayName("إسم السائق")]
        public string? DriverName { get; set; }
        [DisplayName(" رخصة السائق")]
        public string? DriveLicence { get; set; }
        [DisplayName(" رقم الهوية")]
        public string? DriverIdentity { get; set; }

    }
}
