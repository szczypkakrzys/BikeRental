namespace BikeRental.Models
{
    public class RentalPoint
    {
        public int Id { get; set; }
        public List<Vehicle> AllVehiclesList { get; set; }
        public List<Reservation> ReservationsList { get; set; }
    }
}
