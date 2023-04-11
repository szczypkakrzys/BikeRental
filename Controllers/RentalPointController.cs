using AutoMapper;
using BikeRental.DAL;
using BikeRental.Models;
using BikeRental.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace BikeRental.Controllers
{
    public class RentalPointController : Controller
    {
        private IRepository<RentalPoint> _rentalPointRepository;
        private readonly IMapper _mapper;
        public RentalPointController(IMapper mapper)
        {
            _rentalPointRepository = new RepositoryService<RentalPoint>(new DatabaseContext());
            _mapper = mapper;
            //temporary solution to add rental point
            _rentalPointRepository.Add(new RentalPoint { Name = "Punkt wypozyczen nr 1", Location = "Bielsko-Biała ul. Przykładowa 14" });
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

