namespace Meeting.Core.DataAccess.Interfaces;

internal interface IAsyncInsertableRepository<TEntity> : IAsyncRepository where TEntity : BaseEntity
{
	Task<TEntity> AddAsync(TEntity entity);
	Task AddRangeAsync(IEnumerable<TEntity> entities);
}
