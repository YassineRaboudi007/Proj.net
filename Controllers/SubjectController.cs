using Gestion_note.Data;
using Gestion_note.Data.NoteRepo;
using Gestion_note.Data.UnitOfWork;
using Gestion_note.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_note.Controllers
{
    [Route("Subject")]
    public class SubjectController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMatiereRepo _matiereRepo;
        public SubjectController(IMatiereRepo matiereRepo,IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
            _matiereRepo = matiereRepo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable < Matiere > allSubjects= _matiereRepo.GetAll();
            return View(allSubjects);
        }


        [HttpGet]
        [Route("Edit/{id}")]
        public IActionResult Edit(string id)
        {
            Matiere matiere = _matiereRepo.Get(id);
            return View(matiere);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public IActionResult Edit(Matiere mat,string id)
        {
            Matiere matiere = _matiereRepo.Get(id);
            matiere.Name = mat.Name;
            matiere.Coefficent = mat.Coefficent;
            using (_unitOfWork)
            {
                _unitOfWork.Complete();
            }
            return View(matiere);
        }

        [Route("Add")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        

        [HttpPost]
        public IActionResult Add(Matiere matiere)
        {
            if (matiere.Name != null & matiere.Coefficent != null)
            {
                matiere.Id = Guid.NewGuid();
                matiere.FilierMatier = null;
                matiere.FilierMatier = null;
                Console.WriteLine("yay", matiere.Coefficent);
                using (_unitOfWork)
                {
                    _matiereRepo.Add(matiere);
                    _unitOfWork.Complete();
                }


            }
            return View();
        }


    }
}
