using System.Linq.Expressions;

namespace InventoryManagementSystem.RepositoryContract
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
         Task UpdateAsync( TEntity entity);
         Task<bool> Delete(Expression<Func<TEntity, bool>> Predicate);
         Task AddAsync(TEntity entity);
         IQueryable<TEntity> GetItemAsQueryable(Expression<Func<TEntity, bool>> expression);
         IQueryable<TEntity> GetAllWithFilterAsQueryable(Expression<Func<TEntity, bool>> expression);
         IQueryable<TEntity> GetAllAsQueryable();

    }
}
