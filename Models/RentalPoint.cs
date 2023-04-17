namespace BikeRental.Models
{
    public class RentalPoint
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string Location { get; set; }
        public ICollection<Vehicle>? AllVehiclesList { get; set; }
        public ICollection<Reservation>? ReservationsList { get; set; }
        public string EmailAdress { get; set; }
        public string phoneNumber { get; set; }
    }
}
