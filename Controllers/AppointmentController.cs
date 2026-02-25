using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppointmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var appts = _context.Appointments.Include(a => a.Patient);
            return View(await appts.ToListAsync());
        }


        public IActionResult Create()
        {
            LoadDropdownData();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            LoadDropdownData();
            return View(appointment);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var appt = await _context.Appointments.Include(a => a.Patient).FirstOrDefaultAsync(m => m.Id == id);
            if (appt == null) return NotFound();
            return View(appt);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appt = await _context.Appointments.FindAsync(id);
            if (appt != null) { 
                _context.Appointments.Remove(appt); 
                await _context.SaveChangesAsync(); 
            }
            return RedirectToAction(nameof(Index));
        }


        private void LoadDropdownData()
        {

            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Name");


            var doctors = _context.Doctors.Include(d => d.Schedules).ToList();


            ViewBag.DoctorList = doctors.Select(d => new SelectListItem
            {
                Value = d.Name,
                Text = $"{d.Name} ({d.Department})"
            }).ToList();

            ViewBag.DoctorData = doctors;
        }
    }
}