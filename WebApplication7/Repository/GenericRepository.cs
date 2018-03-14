using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApplication7.Persistence;

namespace WebApplication7.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private CarDbContext _db;

        public GenericRepository()
        {
            _db = new CarDbContext();
        }

        public GenericRepository(CarDbContext db)
        {
           _db = db;
        }

        public void Add(T entity)
        {
            _db.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _db.Set<T>().Remove(entity);
        }

        public T GetDetail(Func<T, bool> predicate)
        {
            return _db.Set<T>().First(predicate);
        }

        public IEnumerable<T> GetOverview(Func<T, bool> predicate = null)
        {
            if (predicate != null)
                return _db.Set<T>().Where(predicate);
            return _db.Set<T>().AsEnumerable();
        }

        public async Task<T> AddAsync(T t)
        {
            _db.Set<T>().Add(t);
            await _db.SaveChangesAsync();
            return t;

        }

        public async Task<int> DeleteAsync(T entity)
        {
            _db.Set<T>().Remove(entity);
            return await _db.SaveChangesAsync();
        }
        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _db.SaveChangesAsync();
        }


    }
}