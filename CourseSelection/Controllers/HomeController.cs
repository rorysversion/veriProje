using CourseSelection.Models;
using Microsoft.AspNetCore.Mvc;


namespace CourseSelection.Controllers
{
    public class HomeController : Controller
    {
        
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
