using Gestion_note.Data.Repository;
using Gestion_note.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_note.Data.StudentRepo
{
    public class StudentRepo : Repository<Student>, IStudentRepo
    {
        private readonly AppDbContext _appDbContext;
        public StudentRepo(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Student> GetStudentsWithFilier()
        {
            return _appDbContext.Students.Include(s => s.StudentFilier).ToList();
        }

        public Student GetStudentWithFilier(string id)
        {
            return _appDbContext.Students.Include(s => s.StudentFilier).Where(s => s.Id == Guid.Parse(id)).First();
        }

        public IEnumerable<Student> GetNotesForStudent(int id)
        {
            return _appDbContext.Students
                .Include(s => s.StudentFilier)
                .ThenInclude(f => f.Matieres).ToList();
                
        }

    }
}
