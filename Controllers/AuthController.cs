using Gestion_note.Data.FiliereRepo;
using Gestion_note.Data.StudentRepo;
using Gestion_note.Data.TeacherRepository;
using Gestion_note.Data.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Gestion_note.Models;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Collections.Generic;

namespace Gestion_note.Controllers
{
    [Route("Auth")]
    public class AuthController : Controller
    {
        private readonly IStudentRepo _studentRepo;
        private readonly ITeacherRepo _teacherRepo;
        private readonly IFiliereRepo _filierRepo;
        private readonly IUnitOfWork _unitofwork;


        public AuthController(IStudentRepo studentRepo, ITeacherRepo teacherRepo, IFiliereRepo filierRepo, IUnitOfWork unitofwork)
        {
            _studentRepo = studentRepo;
            _teacherRepo = teacherRepo;
            _filierRepo = filierRepo;
            _unitofwork = unitofwork;
        }

        [Route("login")]
        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }
        [Route("login")]
        [HttpPost]
        public ActionResult Login(string loginName, string loginPassword, string role)
        {
            if (role == "Student")
            {
                IEnumerable<Student> allStudents = _studentRepo.GetStudentsWithFilier();
                Student s = null;
                foreach (Student student in allStudents)
                {
                    if ((student.Name == loginName) && (student.Password == loginPassword))
                    {
                        s = student;
                    }
                }
                if (s != null)
                {
                    HttpContext.Session.SetString("Role", "Student");
                    ViewBag.exits = true;
                    return RedirectToAction("Index", "Student");
                }
                else
                {
                    ViewBag.exist = false;
                    return View("Login");
                }
            }
            else if (role == "Teacher")
            {
                IEnumerable<Teacher> allTeachers = _teacherRepo.GetAll();
                Teacher s = null;
                foreach (Teacher teacher in allTeachers)
                {
                    if ((teacher.Name == loginName) && (teacher.Password == loginPassword))
                    {
                        s = teacher;
                    }
                }
                if (s != null)
                {
                    HttpContext.Session.SetString("Role", "Teacher");
                    ViewBag.exits = true;
                    return RedirectToAction("Teacher/Index");
                }
                else
                {
                    ViewBag.exist = false;
                    return View("Login");
                }

            }

            return View();
        }

        [Route("signup")]
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [Route("signup")]
        [HttpPost]
        public ActionResult SignUp(string loginName, string loginEmail, string loginPassword, string role, List<string> FilierId)
        {

            if (role == "Student")
            {
                Student s = new Student();
                s.Id = Guid.NewGuid();
                s.Name = loginName;
                s.Email = loginEmail;
                s.Password = loginPassword;
                s.StudentFilier = _filierRepo.Get(FilierId.First());
                _studentRepo.Add(s);
                _unitofwork.Complete();


            }
            else if (role == "Teacher")
            {

                Teacher s = new Teacher();
                s.Id = Guid.NewGuid();
                s.Name = loginName;
                s.Email = loginEmail;
                s.Password = loginPassword;
                List<Filier> liste = new List<Filier>();
                foreach (string filid in FilierId)
                {
                    Filier f = _filierRepo.Get(filid);
                    liste.Add(f);
                }
                s.Filiers = liste;
                _teacherRepo.Add(s);
                _unitofwork.Complete();


            }

            return View("Auth/Login");
        }
    }
}
