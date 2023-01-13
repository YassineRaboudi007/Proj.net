using Gestion_note.Models;

namespace Gestion_note.Data.TeacherRepository
{
    public interface ITeacherRepo : IRepository<Teacher>
    {
        IEnumerable<Teacher> GetFiliersForTeacher(int teacherID);
    }
}
