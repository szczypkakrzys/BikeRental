namespace BikeRental.Models
{
    public class RentalPoint
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string Location { get; set; }
        public string EmailAdress { get; set; }
        public string phoneNumber { get; set; }
        public ICollection<Vehicle>? Vehicles { get; set; }
        public ICollection<Reservation>? Reservations { get; set; }
    }
}
