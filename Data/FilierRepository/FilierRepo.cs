using Gestion_note.Data.Repository;
using Gestion_note.Data.TeacherRepository;
using Gestion_note.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_note.Data.FiliereRepo
{
    public class FiliereRepo : Repository<Filier>, IFiliereRepo
    {
        readonly AppDbContext _appDbContext;
        public FiliereRepo(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Filier getFiliereWithMatiere(string id)
        {
            return _appDbContext.Filiers.Include(a => a.Matieres).Where(a=>a.Id==Guid.Parse(id)).First();
        }

    }
}
