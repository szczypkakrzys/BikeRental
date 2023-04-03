namespace BikeRental.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int RentalPointId { get; set; }
        public List<Vehicle> ReservedVehicles { get; set; }
        public DateTime ReservationStart { get; set; }
        public DateTime ReservationEnd { get; set; }
    }
}
