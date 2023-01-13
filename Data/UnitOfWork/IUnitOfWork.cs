namespace Gestion_note.Data.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        bool Complete();
    }
}
