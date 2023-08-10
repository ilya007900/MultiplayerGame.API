using CSharpFunctionalExtensions;

namespace MultiplayerGame.Domain.Common
{
    public interface IRepository<TEntity, TId> 
        where TEntity : Entity<TId> 
        where TId : IComparable<TId>
    {
        Task<TEntity> GetById(TId id, CancellationToken cancellationToken = default);

        Task<TEntity?> FindById(TId id, CancellationToken cancellationToken = default);

        Task<TEntity> Add(TEntity entity);

        Task<TEntity> Delete(TEntity entity);

        Task<int> Save();
    }
}
