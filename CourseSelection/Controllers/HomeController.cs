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
        
        public IActionResult Index()
        {
            return View();
        }
        

        
    }
}
