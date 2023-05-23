using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InterviewTest.Repositories.Abstractions
{
    public abstract class RepositoryBase<T, TContext> where T : class where TContext : DbContext
    {
        public TContext DbContext { get; private set; }
        
        protected RepositoryBase(TContext dbContext)
        {
            DbContext = dbContext;
        }
        public async virtual Task Add(T entity)
        {
            await DbContext.Set<T>().AddAsync(entity);
        }

        public virtual void Update(T entity)
        {
            DbContext.Set<T>().Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            DbContext.Set<T>().Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = DbContext.Set<T>().Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                DbContext.Set<T>().Remove(obj);
        }

        public async virtual Task<T?> GetById(long id)
        {
            return await DbContext.Set<T>().FindAsync(id);
        }

        public async virtual Task<IEnumerable<T>> GetAll()
        {
            return await DbContext.Set<T>().ToListAsync();
        }

        public async virtual Task<IEnumerable<T>> GetMany(Expression<Func<T, bool>> where)
        {
            return await DbContext.Set<T>().Where(where).ToListAsync();
        }

        public async Task<T?> Get(Expression<Func<T, bool>> where)
        {
            return await DbContext.Set<T>().Where(where).FirstOrDefaultAsync<T>();
        }

    }
}
