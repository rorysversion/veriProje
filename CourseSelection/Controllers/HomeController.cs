using CourseSelection.Models;
using Microsoft.AspNetCore.Mvc;


namespace CourseSelection.Controllers
{
    public class HomeController : Controller
    {
        // Login Ekranýný Gösteren Action
        public ActionResult Login()
        {
            return View();
        }

        // Login Ýþlemi için POST Metodu
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string role)
        {
            if (ModelState.IsValid)
            {
                if (role == "Student")
                {
                    // ÖÐRENCÝ GÝRÝÞÝ
                    if (model.Username == "ahmet.yilmaz" && model.PasswordHash == "hashedpassword12")
                    {
                        return RedirectToAction("Details", "Student");
                    }
                }
                else if (role == "Teacher")
                {
                    // ÖÐRETMEN GÝRÝÞÝ
                    if (model.Username == "teacher" && model.PasswordHash == "1234")
                    {
                        return RedirectToAction("TeacherDashboard", "Teacher");
                    }
                }
                ModelState.AddModelError("", "Kullanýcý adý veya þifre hatalý!");
            }
            return View(model);
        }
    }
}
