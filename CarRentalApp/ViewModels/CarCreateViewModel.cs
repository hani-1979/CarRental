using CarRentalApp.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace CarRentalApp.ViewModels
{
    [Keyless]
    public class CarCreateViewModel
    {
        [Key]
        public int CarId { get; set; } 
        public bool HasNoKey => CarId == null;
        public string? CarName { get; set; }
        [DisplayName("الفرع")]
        public int BranchId { get; set; }
        [ValidateNever]
        public Branch? Branch { get; set; }
        [DisplayName("إسم السيارة")]
        
        public int ModeelId { get; set; }
        [ValidateNever]
        public Modeel? Modeel { get; set; }
        [ValidateNever]
        public List<Modeel> modeels { get; set; }
        [DisplayName("وصف السيارة")]
        [ValidateNever]
        public int classificationId { get; set; }
        [ValidateNever]
        public Classification? Classification { get; set; }
        [DisplayName("رقم الهيكل")]
        public string? ChassisNumber { get; set; }
        [DisplayName("سنة الصنع")]
        public DateTime? Yearfmanufacture { get; set; }
        [DisplayName("اللون")]
        public int ColourId { get; set; }
        [ValidateNever]

        public List<Colour> colours { get; set; }
        [DisplayName("رقم اللوحة")]
        public string? PlateNumber { get; set; }
        [ValidateNever]
        public List<Branch> branches { get; set; }
        
        [DisplayName("إسم الشركة المصنعة")]
        public int ManufactorerId { get; set; }
        [ValidateNever]
        public List<Manufactorer> manufactorers { get; set; }
        [ValidateNever]
        public List<Classification> classifications { get; set; }
        [DisplayName("رقم الإستمارة")]
        public string? FormNumber { get; set; }
        [DisplayName("تأريخ بداية الإستمارة")]
        public DateTime? BDFormNumber { get; set; }
        [DisplayName("تأريخ إنتهاء الإستمارة")]
        public DateTime? EDFormNumber { get; set; }
        [DisplayName("رقم الفحص")]
        public string? CheckNumber { get; set; }
        [DisplayName("تأريخ بداية الفحص")]
        public DateTime? BDCheckNumber { get; set; }
        [DisplayName("تأريخ نهاية الفحص")]
        public DateTime? EDCheckNumber { get; set; }
        [DisplayName("رقم الكارت")]
        public string? CartNumber { get; set; }


    }
}
