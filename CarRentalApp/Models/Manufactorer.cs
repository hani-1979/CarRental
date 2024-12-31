namespace CarRentalApp.Models
{
    public class Manufactorer
    {
        public int ManufactorerId { get; set; }
        public string? ManufactorNameAr { get; set; }
        public string? ManufactorNameEn { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
