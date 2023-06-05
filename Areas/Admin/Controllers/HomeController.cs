using BikeRental.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BikeRental.Models;
using BikeRental.ViewModels;

namespace BikeRental.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class HomeController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<User> _userManager;
        public HomeController(DatabaseContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
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
        [HttpPost]
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
