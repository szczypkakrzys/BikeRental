namespace BikeRental.Models
{
    public class VehicleType
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Vehicle>? Vehicles { get; set; }
    }
}
