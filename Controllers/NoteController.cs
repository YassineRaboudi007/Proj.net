using Gestion_note.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Gestion_note.Controllers
{
    public class NoteController : Controller
    {
        public IActionResult Index()
        {
            //UniversityContext universityContext = UniversityContext.Instantiate_UniversityContext();
            NoteRepository noteRepository = new NoteRepository(universityContext);
            foreach (String s in noteRepository.GetNote())
                Debug.WriteLine(s);

            return View(noteRepository.GetNote());

        }
           

        private readonly INotesRepository _notesRepository;

        public NotesController(INotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
        }

        public ActionResult Add(int id)
        {
            ViewBag.EtudiantId = id;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Add(Note note)
        {
            if (!ModelState.IsValid)
            {
                return View(note);
            }

            _notesRepository.AddNote(note);
            return RedirectToAction("Index", "Etudiants");
        }
    }
}
