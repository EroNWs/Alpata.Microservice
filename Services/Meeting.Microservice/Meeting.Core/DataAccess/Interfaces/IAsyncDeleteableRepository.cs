namespace Meeting.Core.DataAccess.Interfaces;

internal interface IAsyncDeleteableRepository<TEntity> : IAsyncRepository where TEntity : BaseEntity
{
	Task DeleteAsync(TEntity entity);
	Task DeleteRangeAsync(IEnumerable<TEntity> entities);
}
