using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Order.Persistence.Concrete
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<TEntity> _table;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _table = context.Set<TEntity>();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _table.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _table.FindAsync(id);
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return _table;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
