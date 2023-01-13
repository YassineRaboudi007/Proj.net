using Microsoft.AspNetCore.Mvc;

namespace Gestion_note.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
