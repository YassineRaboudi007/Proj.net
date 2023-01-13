using Microsoft.AspNetCore.Mvc;

namespace Gestion_note.Controllers
{
    public class NoteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
