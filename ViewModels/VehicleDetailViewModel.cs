using BikeRental.Models;

namespace BikeRental.ViewModels
{
    public class VehicleDetailViewModel
    {
        public Guid Id { get; set; } //temporary property
        public string BrandName { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public bool isElectric { get; set; }
        public double RentCost { get; set; }
        public string Image { get; set; }
        public string categoryName{ get; set; }
    }
}
