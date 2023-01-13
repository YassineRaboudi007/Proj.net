using Gestion_note.Data.Repository;
using Gestion_note.Models;

namespace Gestion_note.Data.FilierRepository
{
    public class FilierRepo : Repository<Filier>, IFilierRepo
    {
        private readonly AppDbContext _appDbContext;
        public FilierRepo(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }


    }
}
