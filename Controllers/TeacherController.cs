using Gestion_note.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Gestion_note.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
<<<<<<< HEAD
        public ActionResult Add(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async ActionResult Add(Teacher teacher)
        {
            Id = teacher.Id;
            Name = teacher.Name;
            Email = teacher.Email;
            Password = teacher.Password;
            StudentFilier = teacher.StudentFilier;

            Unitofwork.Teacher.Edit(teacher);
            Unitofwork.SaveChanges();
            return RedirectToAction("Edit");
        }

        [HttpGet]
        public IActionResult All()
        {
            return View();
        }
        [HttpPost]
        [Route("/All")]
        public IActionResult All()
        {
            UnitOfWork unitOfWork = new UnitOfWork(AppContext.Instance);
            List<Teacher> teacher = unitOfWork.Teacher.GetAll().ToList();
            return View(teacher);
        }
=======

        public IActionResult Add()
        {

            return View();
        }



>>>>>>> b1049d33c43173bdb6e27de473a5f3e4b8997fdc
    }
}
