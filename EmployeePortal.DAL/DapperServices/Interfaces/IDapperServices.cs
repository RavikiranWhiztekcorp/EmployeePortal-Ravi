using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePortal.DAL.Services.Interfaces
{
    public interface IDapperServices<T>
    {
        Task<IEnumerable<T>> ReadAllAsync(T entity);
        Task<T> ReadGetByIdAsync(T entity);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
