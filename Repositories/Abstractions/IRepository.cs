using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InterviewTest.Repositories.Abstractions
{
    public interface IRepository<T,TContext> where T : class where TContext : DbContext
    {
        TContext DbContext { get; } 
        Task Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        Task<T?> GetById(long id);
        Task<T?>Get(Expression<Func<T, bool>> where);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetMany(Expression<Func<T, bool>> where);
    }
}
