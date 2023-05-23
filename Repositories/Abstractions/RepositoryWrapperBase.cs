using Microsoft.EntityFrameworkCore;

namespace InterviewTest.Repositories.Abstractions
{
    public abstract class RepositoryWrapperBase<TContext> : Disposable where TContext : DbContext
    {
        protected TContext DbContext;

        protected RepositoryWrapperBase(TContext context)
        {
            DbContext = context;
        }

        public async Task<int> Commit()
        {
            return await DbContext.SaveChangesAsync();
        }
        protected override void DisposeCore()
        {
            if (DbContext != null)
                DbContext.Dispose();
        }
    }
}
