using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dentista.Core.Interfaces.Repositories
{
    public interface IBaseRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(T[] entity) where T : class;
        void AddRange<T>(T[] entity) where T : class;
        Task<bool> SaveChangesAsync();
    }
}