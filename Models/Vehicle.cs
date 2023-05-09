namespace BikeRental.Models
{
    public class Vehicle
    {
        public Guid Id { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public bool isElectric { get; set; }
        public double RentCost { get; set; }
        public string Image { get; set; }

        public Guid? CategoryId { get; set; }
        public VehicleType CategoryName{ get; set; }
        public Guid? RentalPointId { get; set; }
        public RentalPoint? RentalPoint { get; set; }
        public ICollection<Reservation>? Reservations { get; set; }
    }
}
