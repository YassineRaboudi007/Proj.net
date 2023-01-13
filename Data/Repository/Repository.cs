using System;
using System.Linq.Expressions;

namespace Gestion_note.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _appDbContext;

        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public T Get(int id)
        {
            return _appDbContext.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _appDbContext.Set<T>().ToList();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _appDbContext.Set<T>().Where(predicate);
        }

        public bool Add(T entity)
        {
            try
            {
                _appDbContext.Set<T>().Add(entity);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddRange(IEnumerable<T> entity)
        {
            try
            {
                _appDbContext.Set<T>().AddRange(entity);
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool Remove(T entity)
        {
            try
            {
                _appDbContext.Set<T>().Remove(entity);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool RemoveRange(IEnumerable<T> entity)
        {
            try
            {
                _appDbContext.Set<T>().RemoveRange(entity);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
