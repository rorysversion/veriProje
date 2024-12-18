using CourseSelection.Models;
using Microsoft.AspNetCore.Mvc;


namespace CourseSelection.Controllers
{
    public class HomeController : Controller
    {
        // Login Ekran�n� G�steren Action
        public ActionResult Login()
        {
            return View();
        }

        // Login ��lemi i�in POST Metodu
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string role)
        {
            if (ModelState.IsValid)
            {
                if (role == "Student")
                {
                    // ��RENC� G�R���
                    if (model.Username == "ahmet.yilmaz" && model.PasswordHash == "hashedpassword12")
                    {
                        return RedirectToAction("Details", "Student");
                    }
                }
                else if (role == "Teacher")
                {
                    // ��RETMEN G�R���
                    if (model.Username == "teacher" && model.PasswordHash == "1234")
                    {
                        return RedirectToAction("TeacherDashboard", "Teacher");
                    }
                }
                ModelState.AddModelError("", "Kullan�c� ad� veya �ifre hatal�!");
            }
            return View(model);
        }
    }
}
