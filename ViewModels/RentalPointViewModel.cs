using BikeRental.Models;

namespace BikeRental.ViewModels
{
    public class RentalPointViewModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string Location { get; set; }
        public List<Vehicle>? AllVehiclesList { get; set; }
        public List<Reservation>? ReservationsList { get; set; }
    }
}
