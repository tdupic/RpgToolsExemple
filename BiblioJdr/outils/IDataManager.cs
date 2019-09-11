using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BiblioJdr.outils
{
    public interface IDataManager
    {
        Task<T> AddAsync<T>(T item) where T : class;

        Task<bool> ExistsAsync<T>(T item) where T : class;

        Task<T> GetAsync<T>(T item) where T : class;

        Task<IEnumerable<T>> GetItems<T>(int index, int count) where T : class;

        Task<bool> RemoveAsync<T>(T item) where T : class;

        Task Clear<T>() where T : class;

        Task<T> Update<T>(T item) where T : class;
    }
}
