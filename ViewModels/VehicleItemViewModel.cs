using BikeRental.Models;

namespace BikeRental.ViewModels
{
    public class VehicleItemViewModel
    {
        public Guid Id { get; set; } //temporary property
        public string BrandName { get; set; }
        public string Model { get; set; }
        public string CategoryName { get; set; }
        public double RentCost { get; set; }
        public string Image { get; set; }
    }
}
