using BikeRental.Models;

namespace BikeRental.ViewModels
{
    public class ReservationViewModel
    {
        public Guid Id { get; set; }
        public DateTime ReservationStart { get; set; }
        public DateTime ReservationEnd { get; set; }
        public int TotalCost { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
        public RentalPoint StartRentalPoint { get; set; }
        public RentalPoint EndRentalPoint { get; set; }
    }
}
