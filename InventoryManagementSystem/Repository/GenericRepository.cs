using System.Linq.Expressions;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.RepositoryContract;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Repository
{
    public class GenericRepository<TEntity> :IGenericRepository<TEntity> where TEntity : class
    {
        InventorySystemContext _context;
        public GenericRepository(InventorySystemContext context) {
            _context = context;
        }
        public IQueryable<TEntity> GetAllAsQueryable()
        {
            var data = _context.Set<TEntity>();

           // if (data is BaseModel baseModel) 
            if (typeof(BaseModel).IsAssignableFrom(typeof(TEntity))) 
            {
                return data.Where(e => EF.Property<bool>(e, "IsDeleted") == false);
            }

            return data;
        }
        public IQueryable<TEntity> GetAllWithFilterAsQueryable(Expression<Func<TEntity, bool>> expression)
        {
            var data= _context.Set<TEntity>().Where(expression);

            // if (data is BaseModel baseModel) 
            if (typeof(BaseModel).IsAssignableFrom(typeof(TEntity)))
            {
                return data.Where(e => EF.Property<bool>(e, "IsDeleted") == false);
            }

            return data;
        }
        public IQueryable<TEntity> GetItemAsQueryable(Expression<Func<TEntity, bool>> expression)
        {
            IQueryable<TEntity> data = _context.Set<TEntity>().Where(expression);

            // if (data is BaseModel baseModel) 
            if (typeof(BaseModel).IsAssignableFrom(typeof(TEntity)))
            {
                return data.Where(e => EF.Property<bool>(e, "IsDeleted") == false);
            }

            return data;
        }
        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }
        public async Task<bool> Delete(Expression<Func<TEntity, bool>> Predicate)
        {
            TEntity? result = await this.GetItemAsQueryable(Predicate).FirstOrDefaultAsync();//use get
            if (result is not null && result is BaseModel baseModel)
            {
                baseModel.IsDeleted = true;
                _context.Entry(baseModel).State = EntityState.Modified;//it's saver but need test
                return true;
            }
            return false;
        }
        //Expression<Func<TEntity, bool>> Predicate,
        public async Task UpdateAsync( TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
               
        }
    }
}
