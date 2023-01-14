using Gestion_note.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Gestion_note.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Add()
        {
            
            return View();
        }



    }
}
