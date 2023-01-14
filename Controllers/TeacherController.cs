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

            IEnumerable<Teacher> allStudents = _teacherRepo.GetAll();
            Console.WriteLine("Index",allStudents);

            return View(allStudents);
        }


            /*
        
        [HttpGet]
        [Route("Edit/{id}")]
        public IActionResult Edit(string id)
        {
            Console.WriteLine("Edit");
            Student student = _teacherRepo.GetFiliersForTeacher(id);
            Console.WriteLine(student);
            IEnumerable<Filier> filiers = _filierRepo.GetAll();
            ViewBag.Filier = filiers;
            return View(student);
        
            }
            */
        [HttpPost]
        [Route("Edit/{id}")]
        public IActionResult Edit(Teacher teacher, string FilierId, string id)
        {
            Teacher currTeacher = _teacherRepo.Get(id);
            currTeacher.Name = teacher.Name;
            currTeacher.Email = teacher.Email;
            currTeacher.Password = teacher.Password;
            currTeacher.Email = teacher.Email;

            if (FilierId == "-1")
            {
            }
            else
            {

            }
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

        [Route("Add")]
        [HttpPost]
        public IActionResult Add(string Name, string Password, string Email, string FilierId)
        {

            Teacher student = new Teacher();
            if (FilierId != "-1")
            {
                student.Id = Guid.NewGuid();
                student.Name = Name;
                student.Email = Email;
                student.Password = Password;
                using (_unitOfWork)
                {
                    _teacherRepo.Add(student);
                    _unitOfWork.Complete();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
