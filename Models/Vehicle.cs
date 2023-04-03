namespace BikeRental.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public bool isElectric { get; set; }
        public double RentCost { get; set; }
        public string Image { get; set; }
        public VehicleType CategoryInfo{ get; set; }
    }
}
