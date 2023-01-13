using Gestion_note.Data.Repository;
using Gestion_note.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_note.Data.NoteRepo
{
    public class NoteRepo : Repository<Note>, INoteRepo
    {
        readonly AppDbContext _appDbContext;
        public NoteRepo(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public double GetNoteAvgForMatiere(int idMatiere, string type)
        {
            return _appDbContext.Notes
                .Include(n => n.Matiere)
                .Where(n => n.Matiere.Id == idMatiere & n.TypeExam == type)
                .Select(n => n.NoteDevoir).FirstOrDefault();
        }

        public double GetNoteAvgForStudent(int idStudent)
        {
            return _appDbContext.Notes
                .Include(n => n.Student)
                .Where(n => n.Student.Id == idStudent)
                .Average(n => n.NoteDevoir);
        }

        public double GetNoteParType(int idStudent, string type)
        {
            return _appDbContext.Notes
                .Include(n => n.Student)
                .Where(n => n.Student.Id == idStudent & n.TypeExam == type)
                .Select(n => n.NoteDevoir).FirstOrDefault();
        }
    }
}
