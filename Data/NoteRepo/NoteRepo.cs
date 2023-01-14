using Gestion_note.Data.Repository;
using Gestion_note.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_note.Data.NoteRepo
{
    public class NoteRepo : Repository<Note>, INoteRepo
    {
        private readonly AppDbContext _appDbContext;
        public NoteRepo(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public double GetNoteAvgForMatiere(int idMatiere, string type, Note n)
        {
            return _appDbContext.Notes
                .Include(n => n.Matiere)
                .Where(n => n.Matiere.Id.ToString() == idMatiere.ToString() & n.TypeExam == type)
                .Select(n => n.NoteDevoir).FirstOrDefault();
        }

        public IEnumerable<Note> GetAllNoteWithFilierAndMatiere()
        {
            return _appDbContext.Notes
                .Include(n => n.Matiere)
                .ThenInclude(m => m.FilierMatier)
                .ToList();
        }

        public double GetNoteAvgForMatiere(int idMatiere, string type)
        {
            throw new NotImplementedException();
        }

        public double GetNoteAvgForStudent(int idStudent)
        {
            return _appDbContext.Notes
                .Include(n => n.Student)
                .Where(n => n.Student.Id.ToString() == idStudent.ToString())
                .Average(n => n.NoteDevoir);
        }

        public double GetNoteParType(int idStudent, string type)
        {
            return _appDbContext.Notes
                .Include(n => n.Student)
                .Where(n => n.Student.Id.ToString() == idStudent.ToString() & n.TypeExam == type)
                .Select(n => n.NoteDevoir).FirstOrDefault();
        }

        public IEnumerable<Note> GetNotesForStudent(Student student)
        {
            return _appDbContext.Notes
                .Include(n => n.Student)
                .Include(n => n.Matiere)
                .Where(n => n.Student == student).ToList();
        }
    }
}
