using Microsoft.AspNetCore.Mvc;

namespace Gestion_note.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
