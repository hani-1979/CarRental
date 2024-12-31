using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace CarRentalApp.Models
{
    public class Modeel
    {
        [Key]
        public int ModeelId { get; set; }
        public int ManufactorerId { get; set; }
        [ValidateNever]
        public Manufactorer? Manufactorer { get; set; }
       
        public string? ModeelNameAr { get; set; }
        public string? ModeelNameEn { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
