using Gestion_note.Data.FiliereRepo;
using Gestion_note.Data.NoteRepo;
using Gestion_note.Data.StudentRepo;
using Gestion_note.Data.UnitOfWork;
using Gestion_note.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_note.Controllers
{
    [Route("Filiere")]
    public class FilierController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFiliereRepo _filierRepo;
        private readonly IStudentRepo _studentRepo;
        public FilierController(IFiliereRepo matiereRepo, IUnitOfWork unitOfWork,IStudentRepo studentRepo)
        {
            _unitOfWork = unitOfWork;
            _filierRepo = matiereRepo;
            _studentRepo = studentRepo;
        }

        [HttpGet]
        [Route("Index")]
        [Route("")]
        public IActionResult Index()
        {
            IEnumerable<Filier> allSubjects = _filierRepo.GetAll();
            return View(allSubjects);
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public IActionResult Edit(string id)
        {
            Filier filier = _filierRepo.Get(id);
            return View(filier);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public IActionResult Edit(Filier mat, string id)
        {
            Filier filier = _filierRepo.Get(id);
            filier.Name = mat.Name;
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
            return View();
        }


        [Route("Add")]
        [HttpPost]
        public IActionResult Add(Filier filier)
        {

            if (filier.Name != null)
            {
                filier.Id = Guid.NewGuid();

                using (_unitOfWork)
                {
                    _filierRepo.Add(filier);
                    _unitOfWork.Complete();
                }


            }
            return RedirectToAction("Index");
        }


        [Route("Delete/{id}")]
        [HttpGet]
        public IActionResult Delete(string id)
        {
            Filier filierToDelete = _filierRepo.Get(id);
            using (_unitOfWork)
            {
                _filierRepo.Remove(filierToDelete);
                _unitOfWork.Complete();
            }
            return RedirectToAction("Index");
        }
        [Route("SubjectInFilier/{idStudent}/{IdFilier}")]
        [HttpGet]
        public IActionResult SubjectInFilier(string idStudent, string IdFilier)
        {
            Filier filier = _filierRepo.getFiliereWithMatiere(IdFilier);
            List<Matiere> matiere= filier.Matieres;
            Student student = _studentRepo.Get(idStudent);
            ViewBag.student=student;
            return View(matiere);
        }


    }
}
