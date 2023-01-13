using Gestion_note.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_note.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }


        [HttpPost]
        public IActionResult Add(Teacher teacher, int[] matiereIds, int[] filierIds)
        {
            if (matiereIds.Length >0 )
            Console.WriteLine(matiereIds);
            return View();
        }



    }
}
