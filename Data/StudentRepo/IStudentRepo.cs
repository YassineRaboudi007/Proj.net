using Gestion_note.Models;

namespace Gestion_note.Data.StudentRepo
{
    public interface IStudentRepo : IRepository<Student>
    {
        IEnumerable<Student> GetStudentsWithFilier();
        Student GetStudentWithFilier(string id);
    }
}
