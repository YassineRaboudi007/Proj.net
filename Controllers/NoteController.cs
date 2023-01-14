using Gestion_note.Data.MatiereRepo;
using Gestion_note.Data.NoteRepo;
using Gestion_note.Data.NoteRepo;
using Gestion_note.Data.StudentRepo;
using Gestion_note.Data.UnitOfWork;
using Gestion_note.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Gestion_note.Controllers
{


    [Route("Note")]
    public class NoteController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INoteRepo _noteRepo;
        private readonly IStudentRepo _studentRepo;
        private readonly IMatiereRepo _matiereRepo;

        public NoteController(INoteRepo noteRepo, IUnitOfWork unitOfWork, IStudentRepo studentRepo, IMatiereRepo matiereRepo)
        {
            _unitOfWork = unitOfWork;
            _noteRepo = noteRepo;
            _studentRepo = studentRepo;
            _matiereRepo = matiereRepo;
        }

        [Route("")]
        [Route("Index")]
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Note> allNotes = _noteRepo.GetAll();
            return View(allNotes);
        }


        [HttpGet]
        [Route("Edit/{id}")]
        public IActionResult Edit(string id)
        {
            Note note = _noteRepo.Get(id);
            return View(note);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public IActionResult Edit(Note n, string id)
        {
            Note note = _noteRepo.Get(id);
            note.NoteDevoir = n.NoteDevoir;
            note.TypeExam = n.TypeExam;
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
        public IActionResult Add(double NoteDevoir, string TypeExam, string idStudent, string idmatiere)
        {
            Note note = new Note();

            if (NoteDevoir != null && TypeExam != null && idStudent != "-1" && idmatiere != "-1")
            {

                note.Id = Guid.NewGuid();
                note.NoteDevoir = NoteDevoir;
                note.TypeExam = TypeExam;
                note.Student = _studentRepo.Get(idStudent);
                note.Matiere = _matiereRepo.Get(idmatiere);
                using (_unitOfWork)
                {
                    _noteRepo.Add(note);
                    _unitOfWork.Complete();
                }


            }
            return RedirectToAction("Index");
        }


    }
}
