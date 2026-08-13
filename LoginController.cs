using Microsoft.AspNetCore.Mvc;

namespace CollegeStudentManagement.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
