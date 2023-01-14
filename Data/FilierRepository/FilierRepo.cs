using Gestion_note.Data.Repository;
using Gestion_note.Data.TeacherRepository;
using Gestion_note.Models;

namespace Gestion_note.Data.FiliereRepo
{
    public class FiliereRepo : Repository<Filier>, IFiliereRepo
    {
        readonly AppDbContext _appDbContext;
        public FiliereRepo(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

    }
}
