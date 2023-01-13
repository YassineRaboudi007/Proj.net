namespace Gestion_note.Data.UnitOfWork
{
    public class UnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public bool Complete()
        {
            try
            {
                int res = _appDbContext.SaveChanges();
                if (res> 0)
                {
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            _appDbContext.Dispose();
        }
    }
}
