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
    public class Return1Controller : Controller
    {
        private readonly RideyourentContext _context;

        public Return1Controller(RideyourentContext context)
        {
            _context = context;
        }

        // GET: Return1
        public async Task<IActionResult> Index()
        {
            var rideyourentContext = _context.Return1s.Include(r => r.CarNoNavigation).Include(r => r.Driver);
            return View(await rideyourentContext.ToListAsync());
        }

        // GET: Return1/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Return1s == null)
            {
                return NotFound();
            }

            var return1 = await _context.Return1s
                .Include(r => r.CarNoNavigation)
                .Include(r => r.Driver)
                .FirstOrDefaultAsync(m => m.ReturnId == id);
            if (return1 == null)
            {
                return NotFound();
            }

            return View(return1);
        }

        // GET: Return1/Create
        public IActionResult Create()
        {
            ViewData["CarNo"] = new SelectList(_context.Cars, "CarNo", "CarNo");
            ViewData["DriverId"] = new SelectList(_context.Drivers, "DriverId", "DriverId");
            return View();
        }

        // POST: Return1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReturnId,CarNo,InspectorName,DriverId,ReturnDate,ElapsedDate,Fine")] Return1 return1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(return1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarNo"] = new SelectList(_context.Cars, "CarNo", "CarNo", return1.CarNo);
            ViewData["DriverId"] = new SelectList(_context.Drivers, "DriverId", "DriverId", return1.DriverId);
            return View(return1);
        }

        // GET: Return1/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Return1s == null)
            {
                return NotFound();
            }

            var return1 = await _context.Return1s.FindAsync(id);
            if (return1 == null)
            {
                return NotFound();
            }
            ViewData["CarNo"] = new SelectList(_context.Cars, "CarNo", "CarNo", return1.CarNo);
            ViewData["DriverId"] = new SelectList(_context.Drivers, "DriverId", "DriverId", return1.DriverId);
            return View(return1);
        }

        // POST: Return1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ReturnId,CarNo,InspectorName,DriverId,ReturnDate,ElapsedDate,Fine")] Return1 return1)
        {
            if (id != return1.ReturnId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(return1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Return1Exists(return1.ReturnId))
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
            ViewData["CarNo"] = new SelectList(_context.Cars, "CarNo", "CarNo", return1.CarNo);
            ViewData["DriverId"] = new SelectList(_context.Drivers, "DriverId", "DriverId", return1.DriverId);
            return View(return1);
        }

        // GET: Return1/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Return1s == null)
            {
                return NotFound();
            }

            var return1 = await _context.Return1s
                .Include(r => r.CarNoNavigation)
                .Include(r => r.Driver)
                .FirstOrDefaultAsync(m => m.ReturnId == id);
            if (return1 == null)
            {
                return NotFound();
            }

            return View(return1);
        }

        // POST: Return1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Return1s == null)
            {
                return Problem("Entity set 'RideyourentContext.Return1s'  is null.");
            }
            var return1 = await _context.Return1s.FindAsync(id);
            if (return1 != null)
            {
                _context.Return1s.Remove(return1);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Return1Exists(string id)
        {
          return (_context.Return1s?.Any(e => e.ReturnId == id)).GetValueOrDefault();
        }
    }
}
