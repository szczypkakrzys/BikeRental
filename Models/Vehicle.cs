namespace BikeRental.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool isElectric { get; set; }
        public double rentCost { get; set; }
    }
}
