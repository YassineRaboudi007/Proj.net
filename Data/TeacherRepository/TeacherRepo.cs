using Gestion_note.Data.Repository;
using Gestion_note.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_note.Data.TeacherRepository
{
    public class TeacherRepo : Repository<Teacher>,ITeacherRepo 
    {
        readonly AppDbContext _appDbContext;
        public TeacherRepo(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Teacher GetFiliersAndMatieresForTeacher(string teacherID)
        {
            return _appDbContext.Teachers
                .Include(t => t.Filiers)
                .Include(t => t.Matieres)
                .Where(t => t.Id.ToString() == teacherID.ToString()).First();
        }

        public IEnumerable<Teacher> GetTeacherWithFiliersAndMatieres(string id)
        {
            return _appDbContext.Teachers
                .Include(t => t.Filiers)
                .Include(t => t.Matieres)
                .Where(t => t.Id == Guid.Parse(id))
                .ToList();
        }

        public IEnumerable<Teacher> GetTeachersWithFiliersAndMatieres()
        {
            return _appDbContext.Teachers
                .Include(t => t.Filiers)
                .Include(t => t.Matieres)
                .ToList();
        }
    }
}
