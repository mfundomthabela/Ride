using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ride.Models;

namespace Ride.Controllers
{
    public class RentalsController : Controller
    {
        private readonly RideyourentContext _context;

        public RentalsController(RideyourentContext context)
        {
            _context = context;
        }

        // GET: Rentals
        public async Task<IActionResult> Index()
        {
            var rideyourentContext = _context.Rentals.Include(r => r.CarNoNavigation).Include(r => r.Driver);
            return View(await rideyourentContext.ToListAsync());
        }

        // GET: Rentals/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Rentals == null)
            {
                return NotFound();
            }

            var rental = await _context.Rentals
                .Include(r => r.CarNoNavigation)
                .Include(r => r.Driver)
                .FirstOrDefaultAsync(m => m.RentalNo == id);
            if (rental == null)
            {
                return NotFound();
            }

            return View(rental);
        }

        // GET: Rentals/Create
        public IActionResult Create()
        {
            ViewData["CarNo"] = new SelectList(_context.Cars, "CarNo", "CarNo");
            ViewData["DriverId"] = new SelectList(_context.Drivers, "DriverId", "DriverId");
            return View();
        }

        // POST: Rentals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RentalNo,CarNo,InspectorName,DriverId,RentalFee,StartDate,EndDate")] Rental rental)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rental);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarNo"] = new SelectList(_context.Cars, "CarNo", "CarNo", rental.CarNo);
            ViewData["DriverId"] = new SelectList(_context.Drivers, "DriverId", "DriverId", rental.DriverId);
            return View(rental);
        }

        // GET: Rentals/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Rentals == null)
            {
                return NotFound();
            }

            var rental = await _context.Rentals.FindAsync(id);
            if (rental == null)
            {
                return NotFound();
            }
            ViewData["CarNo"] = new SelectList(_context.Cars, "CarNo", "CarNo", rental.CarNo);
            ViewData["DriverId"] = new SelectList(_context.Drivers, "DriverId", "DriverId", rental.DriverId);
            return View(rental);
        }

        // POST: Rentals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("RentalNo,CarNo,InspectorName,DriverId,RentalFee,StartDate,EndDate")] Rental rental)
        {
            if (id != rental.RentalNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rental);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalExists(rental.RentalNo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarNo"] = new SelectList(_context.Cars, "CarNo", "CarNo", rental.CarNo);
            ViewData["DriverId"] = new SelectList(_context.Drivers, "DriverId", "DriverId", rental.DriverId);
            return View(rental);
        }

        // GET: Rentals/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Rentals == null)
            {
                return NotFound();
            }

            var rental = await _context.Rentals
                .Include(r => r.CarNoNavigation)
                .Include(r => r.Driver)
                .FirstOrDefaultAsync(m => m.RentalNo == id);
            if (rental == null)
            {
                return NotFound();
            }

            return View(rental);
        }

        // POST: Rentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Rentals == null)
            {
                return Problem("Entity set 'RideyourentContext.Rentals'  is null.");
            }
            var rental = await _context.Rentals.FindAsync(id);
            if (rental != null)
            {
                _context.Rentals.Remove(rental);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalExists(string id)
        {
          return (_context.Rentals?.Any(e => e.RentalNo == id)).GetValueOrDefault();
        }
    }
}
