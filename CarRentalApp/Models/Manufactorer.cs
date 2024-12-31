using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;

namespace CarRentalApp.Models
{
    public class Manufactorer
    {
        public int ManufactorerId { get; set; }
        [DisplayName("إسم الشركة عربي")]
        public string? ManufactorNameAr { get; set; }
        [DisplayName("إسم الشركة إنجليزي")]
        public string? ManufactorNameEn { get; set; }
        [ValidateNever]
        public ICollection<Car> Cars { get; set; }
    }
}
