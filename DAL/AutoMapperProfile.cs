using AutoMapper;
using BikeRental.Models;
using BikeRental.ViewModels;

namespace BikeRental.DAL
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Vehicle, VehicleDetailViewModel>();
            CreateMap<Vehicle, VehicleItemViewModel>();
            CreateMap<VehicleDetailViewModel, Vehicle>();
        }
    }
}
