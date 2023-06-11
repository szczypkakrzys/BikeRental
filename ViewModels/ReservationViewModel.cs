using BikeRental.Models;

namespace BikeRental.ViewModels
{
    public class ReservationViewModel
    {
        public Guid Id { get; set; }
        public DateTime ReservationStart { get; set; }
        public DateTime ReservationEnd { get; set; }
        public double TotalCost { get; set; }
        //public ICollection<Vehicle> Vehicles { get; set; }
        public VehicleDetailViewModel VehicleToReserve { get; set; }
        public RentalPointViewModel StartRentalPoint { get; set; }
        public RentalPointViewModel  EndRentalPoint { get; set; }
        public List<RentalPointViewModel> RentalPoints { get; set; }
    }
}
