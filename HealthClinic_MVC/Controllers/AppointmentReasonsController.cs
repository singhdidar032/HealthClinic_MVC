using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HealthClinic_MVC.Data;
using HealthClinic_MVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace HealthClinic_MVC.Controllers
{
    public class AppointmentReasonsController : Controller
    {
        private readonly HealthClinic_DBContext _context;

        public AppointmentReasonsController(HealthClinic_DBContext context)
        {
            _context = context;
        }

        // GET: AppointmentReasons
        public async Task<IActionResult> Index()
        {
            return View(await _context.AppointmentReason.ToListAsync());
        }

        // GET: AppointmentReasons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentReason = await _context.AppointmentReason
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointmentReason == null)
            {
                return NotFound();
            }

            return View(appointmentReason);
        }
        [Authorize]
        // GET: AppointmentReasons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AppointmentReasons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Option,Price")] AppointmentReason appointmentReason)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointmentReason);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appointmentReason);
        }
        [Authorize]
        // GET: AppointmentReasons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentReason = await _context.AppointmentReason.FindAsync(id);
            if (appointmentReason == null)
            {
                return NotFound();
            }
            return View(appointmentReason);
        }

        // POST: AppointmentReasons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Option,Price")] AppointmentReason appointmentReason)
        {
            if (id != appointmentReason.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointmentReason);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentReasonExists(appointmentReason.Id))
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
            return View(appointmentReason);
        }
        [Authorize]
        // GET: AppointmentReasons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentReason = await _context.AppointmentReason
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointmentReason == null)
            {
                return NotFound();
            }

            return View(appointmentReason);
        }

        // POST: AppointmentReasons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointmentReason = await _context.AppointmentReason.FindAsync(id);
            _context.AppointmentReason.Remove(appointmentReason);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentReasonExists(int id)
        {
            return _context.AppointmentReason.Any(e => e.Id == id);
        }
    }
}
