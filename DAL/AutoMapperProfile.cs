using AutoMapper;
using BikeRental.Controllers;
using BikeRental.Models;
using BikeRental.ViewModels;

namespace BikeRental.DAL
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Vehicle, VehicleDetailViewModel>().ReverseMap();
            CreateMap<Vehicle, VehicleItemViewModel>();
            CreateMap<RentalPoint, RentalPointViewModel>().ReverseMap();
            CreateMap<Reservation, ReservationViewModel>().ReverseMap();

        }
    }
}
