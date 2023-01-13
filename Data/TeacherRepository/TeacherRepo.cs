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
        public IEnumerable<Teacher> GetFiliersForTeacher(int teacherID)
        {
            return _appDbContext.Teachers
                .Include(t => t.Filiers)
                .Where(t => t.Id.ToString() == teacherID.ToString()).ToList();
        }
    }
}
