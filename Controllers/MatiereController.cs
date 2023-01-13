using Microsoft.AspNetCore.Mvc;

namespace Gestion_note.Controllers
{
    public class MatiereController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
