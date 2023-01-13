using Microsoft.AspNetCore.Mvc;

namespace Gestion_note.Controllers
{
    public class FiliereController : Controller
    {

        [HttpGet]
        [Route("/All")]
        public IActionResult All()
        {
            UnitOfWork unitOfWork = new UnitOfWork(AppContext.Instance);
            List<Filiere> filiere = unitOfWork.Filiere.GetAll().ToList();
            return View(filiere);
        }

    }
}
