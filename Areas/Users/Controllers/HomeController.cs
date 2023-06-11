using AutoMapper;
using BikeRental.DAL;
using BikeRental.Models;
using BikeRental.ViewModels;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;
using NuGet.Protocol;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing.Text;

namespace BikeRental.Areas.Users.Controllers
{
    [Area("Users")]
    [Authorize(Roles = "User, Operator, Administrator")]
    public class HomeController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<User> _userManager;
        private IRepository<Reservation> _reservations;
        private readonly IMapper _mapper;
        private IValidator<ReservationViewModel> _validator;
        private IRepository<RentalPoint> _rentalPoint;
        public HomeController(DatabaseContext context, UserManager<User> userManager, IMapper mapper, IValidator<ReservationViewModel> validator)
        {
            _reservations = new RepositoryService<Reservation>(new DatabaseContext());
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
            _validator = validator;
            _rentalPoint = new RepositoryService<RentalPoint>(new DatabaseContext());
        }
        // GET: HomeController
        public IActionResult Index()
        {
            return View();
        }
        [Route("User/AllReservations")]
        public IActionResult AllReservations()
        {
            var model = _reservations.GetAllRecords().Where(x => x.userId == _userManager.GetUserId(User));
            var listViewModel = model.Select(viewModel => _mapper.Map<ReservationViewModel>(viewModel)).ToList();

            return View(listViewModel);
        }

        // GET: HomeController/Details/5
        public ActionResult Details(Guid id)
        {
            Reservation info = _reservations.GetSingle(id);
            ReservationViewModel reservationDetails = _mapper.Map<ReservationViewModel>(info);
            reservationDetails.StartRentalPoint = _mapper.Map < RentalPointViewModel > (_rentalPoint.GetSingle(info.StartRentalPointId));
            reservationDetails.EndRentalPoint = _mapper.Map<RentalPointViewModel>(_rentalPoint.GetSingle(info.EndRentalPointId));
            return View(reservationDetails);
        }

        // GET: HomeController/Create
       
        
        public IActionResult Create(string vehicleData)
        {
            VehicleDetailViewModel VehicleToAdd = JsonConvert.DeserializeObject<VehicleDetailViewModel>(vehicleData);
            ReservationViewModel reservation = new ReservationViewModel();
            reservation.VehicleToReserve = VehicleToAdd;
            reservation.TotalCost = VehicleToAdd.RentCost;
            reservation.ReservationEnd=DateTime.Now.AddDays(2);
            reservation.ReservationStart=DateTime.Now.AddDays(1);
            reservation.RentalPoints = _mapper.Map<List<RentalPointViewModel>>(_rentalPoint.GetAllRecords()); 


            return View(reservation);
        }
        private double price(DateTime start, DateTime end, double cost)
        {
            TimeSpan interval = end - start;
            return Convert.ToInt32(interval.TotalDays) * cost;
        }
        [HttpPost]
        public IActionResult Create(ReservationViewModel reservation)
        {
            reservation.TotalCost = price(reservation.ReservationStart, reservation.ReservationEnd, reservation.TotalCost);
            Reservation reservationModel = _mapper.Map<Reservation>(reservation);
            reservationModel.userId = _userManager.GetUserId(User);
            reservationModel.StartRentalPointId = reservation.StartRentalPoint.Id;
            reservationModel.EndRentalPointId = reservation.EndRentalPoint.Id;
            _reservations.Add(reservationModel);
            return RedirectToAction("Index");
        }
        // POST: HomeController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
