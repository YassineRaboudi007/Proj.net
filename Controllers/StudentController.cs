using Gestion_note.Data.FilierRepository;
using Gestion_note.Data.NoteRepo;
using Gestion_note.Data.StudentRepo;
using Gestion_note.Data.UnitOfWork;
using Gestion_note.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gestion_note.Controllers
{
    public class StudentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStudentRepo _studentRepo;
        private readonly IFilierRepo _filierRepo;
        public StudentController(IStudentRepo studentRepo, IUnitOfWork unitOfWork,IFilierRepo filierRepo)
        {
            _unitOfWork = unitOfWork;
            _studentRepo = studentRepo;
            _filierRepo = filierRepo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Student> allStudents = _studentRepo.GetAll();
            return View(allStudents);
        }


        [HttpGet]
        [Route("Edit/{id}")]
        public IActionResult Edit(string id)
        {
            Student matiere = _studentRepo.Get(id);
            return View(matiere);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public IActionResult Edit(Student stdn,int filier, string id)
        {
            Student student = _studentRepo.Get(id);
            student.Name = stdn.Name;
            student.Email = stdn.Email;
            student.Password = stdn.Password;
            if (filier == 0)
            {
                student.StudentFilier = null;
            }
            else
            {
                student.StudentFilier = null;
            }
            student.Email = stdn.Email;
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
            IEnumerable<Filier> filiers = _filierRepo.GetAll();
            ViewBag.Filiers = new MultiSelectList(filiers, "FilierID", "FilierName");

            return View();
        }


        [Route("Add")]
        [HttpPost]
        public IActionResult Add(Student student)
        {
            if (student.Name != null & student.Email != null)
            {
                student.Id = Guid.NewGuid();
                student.StudentFilier = null;
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
