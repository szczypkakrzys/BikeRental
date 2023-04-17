namespace BikeRental.Models
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public Guid RentalPointId { get; set; }
        public ICollection<Vehicle> ReservedVehicles { get; set; }
        public int TotalCost { get; set; }
        public DateTime ReservationStart { get; set; }
        public DateTime ReservationEnd { get; set; }
    }
}
