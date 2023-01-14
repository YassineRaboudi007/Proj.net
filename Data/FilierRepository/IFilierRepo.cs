using Gestion_note.Models;

namespace Gestion_note.Data.FiliereRepo
{
    public interface IFiliereRepo : IRepository<Filier>
    {
        Filier getFiliereWithMatiere(string id);
    }
}
