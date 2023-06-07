using AutoMapper;
using BikeRental.DAL;
using BikeRental.Models;
using BikeRental.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BikeRental.Areas.Users.Controllers
{
    [Area("Users")]
    [Authorize(Roles = "User")]
    public class HomeController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<User> _userManager;
        private IRepository<Reservation> _reservations;
        private readonly IMapper _mapper;
        public HomeController(DatabaseContext context, UserManager<User> userManager, IMapper mapper)
        {
            _reservations = new RepositoryService<Reservation>(new DatabaseContext());
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
        }
        // GET: HomeController
        public IActionResult Index()
        {
            return View();
        }
        [Route("User/AllReservations")]
        public IActionResult AllReservations()
        {
            var model = _reservations.GetAllRecords();
            var listViewModel = model.Select(viewModel => _mapper.Map<ReservationViewModel>(viewModel)).ToList();

            return View(listViewModel);
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController/Create
        public ActionResult Create(IEnumerable<VehicleItemViewModel> vehiclesList)
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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
