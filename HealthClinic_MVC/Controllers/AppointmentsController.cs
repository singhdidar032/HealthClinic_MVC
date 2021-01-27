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
    public class AppointmentsController : Controller
    {
        private readonly HealthClinic_DBContext _context;

        public AppointmentsController(HealthClinic_DBContext context)
        {
            _context = context;
        }

        // GET: Appointments
        public async Task<IActionResult> Index()
        {
            var healthClinic_DBContext = _context.Appointment.Include(a => a.Doctor).Include(a => a.Patient).Include(a => a.ReasonForAppointment);
            return View(await healthClinic_DBContext.ToListAsync());
        }

        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Include(a => a.ReasonForAppointment)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        [Authorize]
        // GET: Appointments/Create
        public IActionResult Create()
        {
            ViewData["DoctorId"] = new SelectList(_context.Set<Doctor>(), "Id", "Name");
            ViewData["PatientId"] = new SelectList(_context.Set<Patient>(), "Id", "Name");
            ViewData["ReasonForAppointmentId"] = new SelectList(_context.Set<AppointmentReason>(), "Id", "Option");
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PatientId,DoctorId,ReasonForAppointmentId,AppDate")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorId"] = new SelectList(_context.Set<Doctor>(), "Id", "Name", appointment.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Set<Patient>(), "Id", "Name", appointment.PatientId);
            ViewData["ReasonForAppointmentId"] = new SelectList(_context.Set<AppointmentReason>(), "Id", "Option", appointment.ReasonForAppointmentId);
            return View(appointment);
        }
        [Authorize]
        // GET: Appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.Set<Doctor>(), "Id", "Name", appointment.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Set<Patient>(), "Id", "Name", appointment.PatientId);
            ViewData["ReasonForAppointmentId"] = new SelectList(_context.Set<AppointmentReason>(), "Id", "Option", appointment.ReasonForAppointmentId);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PatientId,DoctorId,ReasonForAppointmentId,AppDate")] Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.Id))
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
            ViewData["DoctorId"] = new SelectList(_context.Set<Doctor>(), "Id", "Name", appointment.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Set<Patient>(), "Id", "Name", appointment.PatientId);
            ViewData["ReasonForAppointmentId"] = new SelectList(_context.Set<AppointmentReason>(), "Id", "Option", appointment.ReasonForAppointmentId);
            return View(appointment);
        }

        [Authorize]
        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Include(a => a.ReasonForAppointment)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _context.Appointment.FindAsync(id);
            _context.Appointment.Remove(appointment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointment.Any(e => e.Id == id);
        }
    }
}
