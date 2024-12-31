using System.ComponentModel;

namespace CarRentalApp.Models
{
    public class Colour
    {
        public int ColourId { get; set; }
        [DisplayName("إسم اللون عربي")]
        public string? ColourNameAr { get; set; }
        [DisplayName("إسم اللون إنجليزي")]
        public string? ColourNameEn { get; set; }

    }
}
