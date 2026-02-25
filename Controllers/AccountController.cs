using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class AccountController : Controller
    {

        public IActionResult Login(string role)
        {

            if (role == "Admin" && HttpContext.Session.GetString("UserRole") == "Admin")
            {
                return RedirectToAction("Index", "Doctor");
            }

            ViewData["Role"] = role;
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password, string role)
        {

            if (role == "Admin")
            {

                if (username == "admin" && password == "12345")
                {
                    HttpContext.Session.SetString("UserRole", "Admin");
                    return RedirectToAction("Index", "Doctor");
                }
                else
                {
                    ViewBag.Error = "Invalid Username or Password!";
                    ViewData["Role"] = role;
                    return View();
                }

            }

            if (role == "Doctor") return RedirectToAction("Index", "Doctor");
            if (role == "Patient") return RedirectToAction("Create", "Appointment");
            
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}