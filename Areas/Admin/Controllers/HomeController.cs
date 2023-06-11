using BikeRental.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BikeRental.Models;
using BikeRental.ViewModels;
using AutoMapper;

namespace BikeRental.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
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
        [Route("Admin/Panel")]
        public IActionResult Panel()
        {
            return View();
        }
        [Route("Admin/Users")]
        public IActionResult Users()
        {
            var usersList = _context.Users.ToList();
            return View(usersList);
        }
        [Route("Admin/Reservations")]
        public IActionResult Reservations()
        {
            IEnumerable<Reservation> model = _reservations.GetAllRecords();
            return View(model);
        }
        [HttpGet]
        public IActionResult DeleteReservation(Guid id) 
        { 
            Reservation toDelete = _reservations.GetSingle(id);
            ReservationViewModel toDeleteVm = _mapper.Map<ReservationViewModel>(toDelete);
            return View(toDeleteVm); 
        }
        [HttpPost]
        public IActionResult DeleteReservation(ReservationViewModel reservation)
        {
            Reservation reservationModel = _mapper.Map<Reservation>(reservation);
            _reservations.Delete(reservationModel);
            return RedirectToAction("Reservations");
        }
        public IActionResult FinishReservation(Guid id)
        {
            var model = _reservations.GetSingle(id);
            model.isFinished = true;
            _reservations.Edit(model);
            return RedirectToAction("Reservations");
        }
        public async Task<IActionResult> OperatorRole(Guid id)
        {
            User user = await _userManager.FindByIdAsync(id.ToString());
            await _userManager.AddToRoleAsync(user, "Operator");
            return RedirectToAction("Admin/Users");
        }
        //public async Task<IList <string>> Role(Guid id)
        //{
        //    var user = await _userManager.FindByIdAsync(id.ToString());
        //    var role = await _userManager.GetRolesAsync(user);
            
        //    return role;
        //}
    }
}
