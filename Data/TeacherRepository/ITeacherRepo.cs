using Gestion_note.Models;

namespace Gestion_note.Data.TeacherRepository
{
    public interface ITeacherRepo : IRepository<Teacher>
    {
        Teacher GetFiliersAndMatieresForTeacher(string teacherID);
        IEnumerable<Teacher> GetTeacherWithFiliersAndMatieres(string id);
        IEnumerable<Teacher> GetTeachersWithFiliersAndMatieres();

    }
}
