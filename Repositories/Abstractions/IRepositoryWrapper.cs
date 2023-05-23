using System.Linq.Expressions;

namespace InterviewTest.Repositories.Abstractions
{
    public interface IReadOnlyRepositoryWrapper<TValue,TEntity> where TValue: struct where TEntity : class
    {
        Task<TEntity?> GetAsync(TValue id);
        Task<TEntity?> FindAsync(Expression<Func<TEntity,bool>> expression);
        Task<ICollection<TEntity>> SearchAsync(Expression<Func<TEntity,bool>> expression);
        Task<ICollection<TEntity>> GetAllAsync();

    }

    public interface IWriteOnlyRepositoryWrapper<TValue, TEntity> where TValue : struct where TEntity : class
    {
        Task<int> CreateAsync(TEntity entity);
        Task<int> UpdateAsync(TEntity entity);
        Task<int> RemoveAsync(TValue id);
    }
}
