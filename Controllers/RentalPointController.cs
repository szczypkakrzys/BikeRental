using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BikeRental.DAL;
using BikeRental.Models;
using NuGet.Protocol;

namespace BikeRental.Controllers
{
    public class RentalPointController : Controller
    {
        private IRepository<RentalPoint> _rentalPointRepository;

        public RentalPointController()
        {
            _rentalPointRepository = new RepositoryService<RentalPoint>(new DatabaseContext());
            //temporary solution to add rental point
            _rentalPointRepository.Add(new RentalPoint { Name = "Punkt wypozyczen nr 1", Location = "Bielsko-Biała ul. Przykładowa 14" });
        }

        public IActionResult Index()
        {
            var model = _rentalPointRepository.GetAllRecords();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(RentalPoint rentalPoint)
        {
            _rentalPointRepository.Add(rentalPoint);
            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid id)
        {
            RentalPoint info = _rentalPointRepository.GetSingle(id);
            return View(info);
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            return Details(id);
        }
        [HttpPost]
        public IActionResult Edit (RentalPoint rentalPoint)
        {
            _rentalPointRepository.Edit(rentalPoint);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            return Details(id);
        }
        [HttpPost]
        public IActionResult Delete(RentalPoint rentalPoint)
        {
            _rentalPointRepository.Delete(rentalPoint);
            return RedirectToAction("Index");
        }
    }
}

//        // GET: RentalPoint
//        public async Task<IActionResult> Index()
//        {
//              return _context.RentalPoint != null ? 
//                          View(await _context.RentalPoint.ToListAsync()) :
//                          Problem("Entity set 'DatabaseContext.RentalPoint'  is null.");
//        }

//        // GET: RentalPoint/Details/5
//        public async Task<IActionResult> Details(Guid? id)
//        {
//            if (id == null || _context.RentalPoint == null)
//            {
//                return NotFound();
//            }

//            var rentalPoint = await _context.RentalPoint
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (rentalPoint == null)
//            {
//                return NotFound();
//            }

//            return View(rentalPoint);
//        }

//        // GET: RentalPoint/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: RentalPoint/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,Name,Location")] RentalPoint rentalPoint)
//        {
//            if (ModelState.IsValid)
//            {
//                rentalPoint.Id = Guid.NewGuid();
//                _context.Add(rentalPoint);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(rentalPoint);
//        }

//        // GET: RentalPoint/Edit/5
//        public async Task<IActionResult> Edit(Guid? id)
//        {
//            if (id == null || _context.RentalPoint == null)
//            {
//                return NotFound();
//            }

//            var rentalPoint = await _context.RentalPoint.FindAsync(id);
//            if (rentalPoint == null)
//            {
//                return NotFound();
//            }
//            return View(rentalPoint);
//        }

//        // POST: RentalPoint/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Location")] RentalPoint rentalPoint)
//        {
//            if (id != rentalPoint.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(rentalPoint);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!RentalPointExists(rentalPoint.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(rentalPoint);
//        }

//        // GET: RentalPoint/Delete/5
//        public async Task<IActionResult> Delete(Guid? id)
//        {
//            if (id == null || _context.RentalPoint == null)
//            {
//                return NotFound();
//            }

//            var rentalPoint = await _context.RentalPoint
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (rentalPoint == null)
//            {
//                return NotFound();
//            }

//            return View(rentalPoint);
//        }

//        // POST: RentalPoint/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(Guid id)
//        {
//            if (_context.RentalPoint == null)
//            {
//                return Problem("Entity set 'DatabaseContext.RentalPoint'  is null.");
//            }
//            var rentalPoint = await _context.RentalPoint.FindAsync(id);
//            if (rentalPoint != null)
//            {
//                _context.RentalPoint.Remove(rentalPoint);
//            }
            
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool RentalPointExists(Guid id)
//        {
//          return (_context.RentalPoint?.Any(e => e.Id == id)).GetValueOrDefault();
//        }
//    }
//}
