using Gestion_note.Data.Repository;
using Gestion_note.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_note.Data.NoteRepo
{
    public class MatiereRepo : Repository<Matiere>, IMatiereRepo
    {
        readonly AppDbContext _appDbContext;
        public MatiereRepo(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

    }
}
