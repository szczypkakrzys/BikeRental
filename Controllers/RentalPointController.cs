using AutoMapper;
using BikeRental.DAL;
using BikeRental.Models;
using BikeRental.ViewModels;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace BikeRental.Controllers
{
    public class RentalPointController : Controller
    {
        private IRepository<RentalPoint> _rentalPointRepository;
        private readonly IMapper _mapper;
        private IValidator<RentalPointViewModel> _validator;
        public RentalPointController(IMapper mapper, IValidator<RentalPointViewModel> validator)
        {
            _rentalPointRepository = new RepositoryService<RentalPoint>(new DatabaseContext());
            _mapper = mapper;
            _validator = validator;
            //temporary solution to add rental point
            _rentalPointRepository.Add(new RentalPoint { Name = "Punkt wypozyczen nr 1", Location = "Bielsko-Biała ul. Przykładowa 14", EmailAdress="wypozyczalnia@athbb.pl", phoneNumber="123456789" });
        }

        public IActionResult Index()
        {
            var model = _rentalPointRepository.GetAllRecords();
            var listViewModel = model.Select(viewModel => _mapper.Map<RentalPointViewModel>(viewModel)).ToList();
            return View(listViewModel);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(RentalPointViewModel rentalPoint)
        {
            ValidationResult result = _validator.Validate(rentalPoint);
            if (!result.IsValid)
            {
                //server-side validation testing
                //var modelStateDictionary = new ModelStateDictionary();
                //foreach (ValidationFailure failure in result.Errors)
                //{
                //    modelStateDictionary.AddModelError(failure.PropertyName, failure.ErrorMessage);
                //}

                //return ValidationProblem(modelStateDictionary);

                //client-side :)
                return View(rentalPoint);
            }
            RentalPoint renatlPointModel = _mapper.Map<RentalPoint>(rentalPoint);
            _rentalPointRepository.Add(renatlPointModel);
            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid id)
        {
            RentalPoint info = _rentalPointRepository.GetSingle(id);
            RentalPointViewModel rentalPointVM = _mapper.Map<RentalPointViewModel>(info);
            return View(rentalPointVM);
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            return Details(id);
        }
        [HttpPost]
        public IActionResult Edit (RentalPointViewModel rentalPoint)
        {
            RentalPoint rentalPointModel = _mapper.Map<RentalPoint>(rentalPoint);
            _rentalPointRepository.Edit(rentalPointModel);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            return Details(id);
        }
        [HttpPost]
        public IActionResult Delete(RentalPointViewModel rentalPoint)
        {
            RentalPoint rentalPointModel = _mapper.Map<RentalPoint>(rentalPoint);
            _rentalPointRepository.Delete(rentalPointModel);
            return RedirectToAction("Index");
        }
    }
}

