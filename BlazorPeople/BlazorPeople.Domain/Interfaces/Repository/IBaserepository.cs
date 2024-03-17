using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPeople.Domain.Interfaces.Repository
{
    public interface IBaserepository<T>
    {
        Task Create(T entity);
        IQueryable<T> GetAll();
        Task Update(T entity);
        Task Delete(T entity);
    }
}
