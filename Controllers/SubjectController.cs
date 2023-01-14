using Gestion_note.Data;
using Gestion_note.Data.FiliereRepo;
using Gestion_note.Data.MatiereRepo;
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
        private readonly IFiliereRepo _filiereRepo;

        public SubjectController(IMatiereRepo matiereRepo,IUnitOfWork unitOfWork,IFiliereRepo filiereRepo) 
        {
            _unitOfWork = unitOfWork;
            _matiereRepo = matiereRepo;
            _filiereRepo = filiereRepo;
        }

        [Route("")]
        [Route("Index")]
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable < Matiere > allSubjects= _matiereRepo.GetAllSubjectsWithFilier();
            return View(allSubjects);
        }


        [HttpGet]
        [Route("Edit/{id}")]
        public IActionResult Edit(string id)
        {
            Matiere matiere = _matiereRepo.Get(id);
            IEnumerable<Filier> filiers = _filiereRepo.GetAll();
            ViewBag.filiers = filiers;
            return View(matiere);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public IActionResult Edit(Matiere mat,string id, string[] FilierId)
        {
            Matiere matiere = _matiereRepo.Get(id);
            
            matiere.Name = mat.Name;
            matiere.Coefficent = mat.Coefficent;
            List<Filier> filiers = new List<Filier>();
            if (FilierId.Length > 0 & FilierId[0] != "-1")
            {
                for (int i = 0; i < FilierId.Length; i++)
                {
                    Filier filier = _filiereRepo.Find(f => f.Id.ToString() == FilierId[i]).First();
                    if (filier != null)
                    {
                        filiers.Add(filier);
                    }
                }
            }
            
            matiere.FilierMatier = filiers;

            using (_unitOfWork)
            {
                _unitOfWork.Complete();
            }
            return RedirectToAction("Index");

        }

        [Route("Add")]
        [HttpGet]
        public IActionResult Add()
        {
            IEnumerable<Filier> filiers= _filiereRepo.GetAll();
            ViewBag.filiers = filiers;
            return View();
        }


        [Route("Add")]
        [HttpPost]
        public IActionResult Add(Matiere matiere , string[] FilierId)
        {
           
            if (matiere.Name != null & matiere.Coefficent != null)
            {
                matiere.Id = Guid.NewGuid();
                List<Filier> filiers = new List<Filier>();
                for (int i = 0; i < FilierId.Length; i++)
                {
                    Filier filier = _filiereRepo.Find(f => f.Id.ToString() == FilierId[i]).First();
                    if (filier != null)
                    {
                        filiers.Add(filier);
                    }
                }
                matiere.FilierMatier = filiers;

                using (_unitOfWork)
                {
                    _matiereRepo.Add(matiere);
                    _unitOfWork.Complete();
                }


            }
            return RedirectToAction("Index");
        }


    }
}
