using CarRentalApp.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApp.ViewModels
{
    [Keyless]
    public class ManufaCarViewModel
    {
        public int ManufactorerId { get; set; }
        [ValidateNever]
        public Manufactorer? Manufactorer { get; set; }
        public int ModeelId { get; set; }
        public string? ModeelNameAr { get; set; }
        public string? ModeelNameEn { get; set; }
        [ValidateNever]
        public List<Manufactorer> Manufactorers { get; set; }
        

    }
}
