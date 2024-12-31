using CarRentalApp.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarRentalApp.ViewModels
{
    
    public class ManufaCarViewModel
    {
        [Key]
        public int ModeelId { get; set; }
        [DisplayName("إسم الشركة المصنعة")]
        public int ManufactorerId { get; set; }
        public string ManufactorNameAr { get; set; }
        [ValidateNever]
        public Manufactorer? Manufactorer { get; set; }
        [DisplayName("إسم السيارة عربي ")]
        public string? ModeelNameAr { get; set; }
        [DisplayName("إسم السيارة إنجليزي")]
        public string? ModeelNameEn { get; set; }
        [ValidateNever]
        public List<Manufactorer> Manufactorers { get; set; }
        

    }
}
