using Gestion_note.Data.FiliereRepo;
using Gestion_note.Data.NoteRepo;
using Gestion_note.Data.StudentRepo;
using Gestion_note.Data.UnitOfWork;
using Gestion_note.DTO;
using Gestion_note.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gestion_note.Controllers
{
    [Route("Student")]
    public class StudentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStudentRepo _studentRepo;
        private readonly IFiliereRepo _filierRepo;
        public StudentController(IStudentRepo studentRepo, IUnitOfWork unitOfWork,IFiliereRepo filierRepo)
        {
            _unitOfWork = unitOfWork;
            _studentRepo = studentRepo;
            _filierRepo = filierRepo;
        }

        [Route("")]
        [Route("Index")]
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Student> allStudents = _studentRepo.GetStudentsWithFilier();
            return View(allStudents);
        }


        [HttpGet]
        [Route("Edit/{id}")]
        public IActionResult Edit(string id)
        {
            Console.WriteLine("Edit");
            Student student = _studentRepo.GetStudentWithFilier(id);
            Console.WriteLine(student);
            IEnumerable<Filier> filiers = _filierRepo.GetAll();
            ViewBag.Filier = filiers;
            return View(student);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public IActionResult Edit(Student student,string FilierId, string id)
        {
            Student currStudent = _studentRepo.Get(id);
            currStudent.Name = student.Name;
            currStudent.Email = student.Email;
            currStudent.Password = student.Password;
            currStudent.Email = student.Email;

            if (FilierId == "-1")
            {
                currStudent.StudentFilier = null;
            }
            else
            {
                currStudent.StudentFilier = _filierRepo.Get(FilierId);

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
            return View();
        }

        [Route("Add")]
        [HttpPost]
        public IActionResult Add(string Name,string Password,string Email,string FilierId)
        {

            Student student = new Student();
            if (FilierId  != "-1")
            {
                student.Id = Guid.NewGuid();
                student.Name = Name;
                student.Email = Email;
                student.Password = Password;
                student.StudentFilier = _filierRepo.Get(FilierId);
                using (_unitOfWork)
                {
                    _studentRepo.Add(student);
                    _unitOfWork.Complete();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
