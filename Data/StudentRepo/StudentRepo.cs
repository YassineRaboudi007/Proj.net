using Gestion_note.Data.Repository;
using Gestion_note.Models;

namespace Gestion_note.Data.StudentRepo
{
    public class StudentRepo : Repository<Student>, IStudentRepo
    {
        public StudentRepo(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
