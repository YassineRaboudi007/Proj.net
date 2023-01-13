using Gestion_note.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Gestion_note.Controllers
{
    public class MatiereController : Controller
    {
        public IActionResult Index()
        {

            return View(MatiereRepository.GetMatieres());

        }
        [HttpGet]
        public IActionResult Add(int id)
        {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Add(int id)
        {
            ViewBag.ERROR = "";
            if(id==0)
            {
                return View("add_matiere", new Matiere);
            }
            else
            {
                return View("add_matiere", unitofwork.Matiere.GetByID(id));
            }
        }
         [HttpGet]
         public IActionResult All()
            {
                 return View();
             }
          [HttpPost]
          [Route("/All")]
          public IActionResult All()
             {
                UnitOfWork unitOfWork = new UnitOfWork(AppContext.Instance);
                List<Matiere> matiere = unitOfWork.Matiere.GetAll().ToList();
                return View(matiere);
                }

}
         
        
}
