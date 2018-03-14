using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication7.Repository
{
 public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetOverview(Func<T, bool> predicate = null);
        T GetDetail(Func<T, bool> predicate);
        void Add(T entity);
        void Delete(T entity);
        Task<int> DeleteAsync(T entity);
        Task<T> AddAsync(T entity);
        void SaveChanges();
        Task<int> SaveAsync();
    }
}
