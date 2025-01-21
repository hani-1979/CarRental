using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace CarRentalApp.Models
{
    public class Car
    {
        [DisplayName("رقم الموديل")]
        public int CarId { get; set; }
      
        public int BranchId { get; set; }
        [ValidateNever]
        public Branch?  Branch { get; set; }

        public int ManufactorerId { get; set; }
        [ValidateNever]
        public Manufactorer? Manufactorer { get; set; }
       
        public int ModeelId { get; set; }
        [ValidateNever]
        public Modeel? Modeel { get; set; }
        public int classificationId { get; set; }
        [ValidateNever]
        public Classification? Classification { get; set; }
        [DisplayName("رقم الهيكل")] 
        
        public string? ChassisNumber { get; set; }
        public DateTime? Yearfmanufacture { get; set; }
        public int ColourId { get; set; }
        [ValidateNever]
        public Colour? Colours { get; set; }
        [Required(ErrorMessage = "الرجاء أدخال ")]
        [DisplayName("رقم اللوحة")]
        public string? PlateNumber { get; set; }
         public string? FormNumber { get; set; }
        public DateTime? BDFormNumber { get; set; }
        public DateTime? EDFormNumber { get; set; }
        public string? CheckNumber { get; set; }
        public DateTime? BDCheckNumber { get; set; }
        public DateTime? EDCheckNumber { get; set; }
        public string? CartNumber { get; set; }
        public DateTime EDCartNumber { get; set; }
        public int AccidenStatus { get; set; }
        public int InsuraceStatus { get; set; }
        public int ClaimStatus { get; set; }
       


    }
}
