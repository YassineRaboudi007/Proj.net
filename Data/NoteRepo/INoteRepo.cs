using Gestion_note.Models;

namespace Gestion_note.Data.NoteRepo
{
    public interface INoteRepo : IRepository<Note>
    {
        double GetNoteParType(int idStudent,string type);
        double GetNoteAvgForStudent(int idStudent); 
        double GetNoteAvgForMatiere(int idMatiere,string type);
        IEnumerable<Note> GetNotesForStudent(Student student);
    }
}
