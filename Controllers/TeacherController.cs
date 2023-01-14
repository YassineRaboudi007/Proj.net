using Gestion_note.Data.FiliereRepo;
using Gestion_note.Data.MatiereRepo;
using Gestion_note.Data.NoteRepo;
using Gestion_note.Data.StudentRepo;
using Gestion_note.Data.TeacherRepository;
using Gestion_note.Data.UnitOfWork;
using Gestion_note.DTO;
using Gestion_note.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Gestion_note.Controllers
{
    [Route("Teacher")]
    public class TeacherController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITeacherRepo _teacherRepo;
        private readonly IFiliereRepo _filierRepo;
        private readonly IMatiereRepo _matiereRepo;
        public TeacherController(IMatiereRepo matiereRepo, ITeacherRepo teacherRepo, IUnitOfWork unitOfWork, IFiliereRepo filierRepo)
        {
            _matiereRepo = matiereRepo;
            _unitOfWork = unitOfWork;
            _teacherRepo = teacherRepo;
            _filierRepo = filierRepo;
        }

        [Route("")]
        [Route("Index")]
        [HttpGet]
        public IActionResult Index()
        {
            Console.WriteLine("Index");
            IEnumerable<Teacher> allStudents = _teacherRepo.GetTeachersWithFiliersAndMatieres();
            return View(allStudents);
        }


            
        
        [HttpGet]
        [Route("Edit/{id}")]
        public IActionResult Edit(string id)
        {
            Console.WriteLine("Edit");
            Teacher teacher = _teacherRepo.GetFiliersAndMatieresForTeacher(id);
            IEnumerable<Filier> filiers = _filierRepo.GetAll();
            ViewBag.Filier = filiers;
            IEnumerable<Matiere> matieres = _matiereRepo.GetAll();
            ViewBag.Matiere = matieres;
            return View(teacher);
        
            }
            
        [HttpPost]
        [Route("Edit/{id}")]
        public IActionResult Edit(Teacher teacher, string[] matiereIds, string[] filierIds, string id)
        {
            Teacher currTeacher = _teacherRepo.Get(id);
            currTeacher.Name = teacher.Name;
            currTeacher.Email = teacher.Email;
            currTeacher.Password = teacher.Password;
            currTeacher.Email = teacher.Email;
            List<Filier> filiers = new List<Filier>();
            for (int i = 0; i < filierIds.Length; i++)
            {
                Filier filier = _filierRepo.Find(f => f.Id.ToString() == filierIds[i]).First();
                if (filier != null)
                {
                    filiers.Add(filier);
                }
            }

            List<Matiere> mats = new List<Matiere>();
            for (int i = 0; i < matiereIds.Length; i++)
            {
                Matiere matiere = _matiereRepo.Find(f => f.Id.ToString() == filierIds[i]).FirstOrDefault();
                if (matiere != null)
                {
                    mats.Add(matiere);
                }
            }

            currTeacher.Filiers = filiers;
            currTeacher.Matieres = mats;
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
            Console.WriteLine("Add");
            IEnumerable<Filier> filiers = _filierRepo.GetAll();
            ViewBag.Filier = filiers;
            IEnumerable<Matiere> matieres = _matiereRepo.GetAll();
            ViewBag.Matiere = matieres;
            return View();
        }


        [Route("TeacherSubject/{id}")]
        [HttpGet]
        public ActionResult TeacherSubject(string id)
        {
            IEnumerable<Teacher> teachers = _teacherRepo.GetTeacherWithFiliersAndMatieres(id);
            return View(teachers);
        }

        [Route("Add")]
        [HttpPost]
        public IActionResult Add(Teacher teacher, string[] matiereIds, string[] filierIds, string id)
        {
            Console.WriteLine("matiereIds", matiereIds);
            Console.WriteLine("filierIds", filierIds);
            Teacher currTeacher = new Teacher();
            currTeacher.Name = teacher.Name;
            currTeacher.Email = teacher.Email;
            currTeacher.Password = teacher.Password;
            currTeacher.Email = teacher.Email;
            List<Filier> filiers = new List<Filier>();
            for (int i = 0; i < filierIds.Length; i++)
            {
                Filier filier = _filierRepo.Find(f => f.Id.ToString() == filierIds[i]).First();
                if (filier != null)
                {
                    filiers.Add(filier);
                }
            }

            List<Matiere> mats = new List<Matiere>();
            for (int i = 0; i < matiereIds.Length; i++)
            {
                Matiere matiere= _matiereRepo.Find(f => f.Id.ToString() == filierIds[i]).FirstOrDefault();
                if (matiere != null)
                {
                    mats.Add(matiere);
                }
            }

            currTeacher.Filiers = filiers;
            currTeacher.Matieres = mats;



            using (_unitOfWork)
            {
                _teacherRepo.Add(currTeacher);
                _unitOfWork.Complete();
            }
            return RedirectToAction("Index");
        }

        [Route("Delete/{id}")]
        [HttpGet]
        public IActionResult Delete(string id)
        {
            Teacher teacher= _teacherRepo.Get(id);
            using (_unitOfWork)
            {
                _teacherRepo.Remove(teacher);
                _unitOfWork.Complete();
            }
            return RedirectToAction("Index");
        }
    }
}
