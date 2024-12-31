using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CarRentalApp.Models
{
    public class Modeel
    {
        public int ManufactorerId { get; set; }
        [ValidateNever]
        public Manufactorer? Manufactorer { get; set; }
        public int ModeelId { get; set; } 
        public string? ModeelNameAr { get; set; }
        public string? ModeelNameEn { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
