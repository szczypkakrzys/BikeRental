namespace BikeRental.Models
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public int TotalCost { get; set; }
        public DateTime ReservationStart { get; set; }
        public DateTime ReservationEnd { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }
        public ICollection<RentalPoint> RentalPoints { get; set; }
        public Guid StartRentalPointId { get; set; }
        public Guid EndRentalPointId { get; set; }
    }
}
