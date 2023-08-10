using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using MultiplayerGame.Domain.Common;

namespace MultiplayerGame.Infrastructure.Database.Repositories
{
    public abstract class Repository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : Entity<TId>
        where TId : IComparable<TId>
    {
        private readonly MultiplayerGameDbContext _dbContext;

        public Repository(MultiplayerGameDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<TEntity> Add(TEntity entity)
        {
            return Task.FromResult(_dbContext.Set<TEntity>().Add(entity).Entity);
        }

        public Task<TEntity> Delete(TEntity entity)
        {
            return Task.FromResult(_dbContext.Remove(entity).Entity);
        }

        public Task<TEntity?> FindById(TId id, CancellationToken cancellationToken = default)
        {
            return _dbContext.Set<TEntity>().SingleOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
        }

        public Task<TEntity> GetById(TId id, CancellationToken cancellationToken = default)
        {
            return _dbContext.Set<TEntity>().SingleAsync(x => x.Id.Equals(id), cancellationToken);
        }

        public Task<int> Save()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
