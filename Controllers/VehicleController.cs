using AutoMapper;
using BikeRental.DAL;
using BikeRental.Models;
using BikeRental.Validators;
using BikeRental.ViewModels;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Data;
using System.Globalization;

namespace BikeRental.Controllers
{
    public class VehicleController : Controller
    {
        private IRepository<Vehicle> _vehicleRepository;
        private readonly IMapper _mapper;
        private IValidator<VehicleDetailViewModel> _validator;
        public VehicleController(IMapper mapper, IValidator<VehicleDetailViewModel> validator)
        {
            _vehicleRepository = new RepositoryService<Vehicle>(new DatabaseContext());
            _mapper = mapper;
            _validator = validator;           
        }

        public IActionResult Index() 
        {
            var model = _vehicleRepository.GetAllRecords();
            var listViewModel = model.Select(viewModel => _mapper.Map<VehicleItemViewModel>(viewModel)).ToList();
         
            return View(listViewModel);
        }
        [Authorize(Roles = "Operator, Administrator")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(VehicleDetailViewModel vehicle) 
        {
            ValidationResult result = _validator.Validate(vehicle);
            if (!result.IsValid)
            {
                //server-side validation testing
                //var modelStateDictionary = new ModelStateDictionary();
                //foreach(ValidationFailure failure in result.Errors)
                //{
                //    modelStateDictionary.AddModelError(failure.PropertyName, failure.ErrorMessage);
                //}
               
                //return ValidationProblem(modelStateDictionary);

                //client-side :)
                return View(vehicle);
            }

            Vehicle vehicleModel = _mapper.Map<Vehicle>(vehicle);
            _vehicleRepository.Add(vehicleModel);
            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid id)
        {
            Vehicle info = _vehicleRepository.GetSingle(id);
            VehicleDetailViewModel vehicleDetails = _mapper.Map<VehicleDetailViewModel>(info);
            return View(vehicleDetails);
        }
        [Authorize(Roles = "Operator, Administrator")]
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            return Details(id);
        }
        [HttpPost]
        public IActionResult Edit(VehicleDetailViewModel vehicle)
        {
            ValidationResult result = _validator.Validate(vehicle);
            if (!result.IsValid)
            {
                //server-side validation testing
                //var modelStateDictionary = new ModelStateDictionary();
                //foreach(ValidationFailure failure in result.Errors)
                //{
                //    modelStateDictionary.AddModelError(failure.PropertyName, failure.ErrorMessage);
                //}

                //return ValidationProblem(modelStateDictionary);

                //client-side :)
                return View(vehicle);
            }
            Vehicle vehicleModel = _mapper.Map<Vehicle>(vehicle);
            _vehicleRepository.Edit(vehicleModel);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Operator, Administrator")]
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            return Details(id);
        }

        [HttpPost]
        public IActionResult Delete(VehicleDetailViewModel vehicle)
        {
            Vehicle vehicleModel = _mapper.Map<Vehicle>(vehicle);
            _vehicleRepository.Delete(vehicleModel);
            return RedirectToAction("Index");
        }
        
        public IActionResult AddToReservation(Guid Id)
        {
            Vehicle vehicleToReserve = _vehicleRepository.GetSingle(Id);
            VehicleDetailViewModel vehicle = _mapper.Map<VehicleDetailViewModel>(vehicleToReserve);
            string vehicleSerialized = JsonConvert.SerializeObject(vehicle);
            return RedirectToAction("Create", "Home", new {area ="Users", vehicleData= vehicleSerialized });
        }
 
    }
}
