using Microsoft.AspNetCore.Mvc;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
using System.Linq; 

namespace HospitalManagementSystem.Controllers
{
    public class PatientController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            
            return View(_context.Patients.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patient);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            
            var patient = _context.Patients.Find(id);
            if (patient == null) return NotFound();
            return View(patient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Patient patient)
        {
            if (id != patient.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(patient);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

           
            var patient = _context.Patients.FirstOrDefault(m => m.Id == id);
            if (patient == null) return NotFound();

            return View(patient);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var patient = _context.Patients.Find(id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}