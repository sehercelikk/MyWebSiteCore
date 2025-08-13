using Microsoft.EntityFrameworkCore;
using MyWebSite.Core.DataAccess.Abstract;
using MyWebSite.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.Core.DataAccess.Concrete;

public class EfGenericRepository<TEntity> : IGenericDal<TEntity> where TEntity : class, IEntity, new()
{
    protected readonly DbContext _context;

    public EfGenericRepository(DbContext context)
    {
        _context = context;
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        return entity;
    }

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter)
    {
        return await _context.Set<TEntity>().AnyAsync(filter);
    }

    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        return entity;
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] expressions)
    {
        IQueryable<TEntity> query = _context.Set<TEntity>();
        if(filter != null)
        {
            query = query.Where(filter);
        }
        if (expressions != null && expressions.Length > 0)
        {
            foreach (var expression in expressions)
            {
                query = query.Include(expression);
            }
        }
        return await query.AsNoTracking().ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await _context.FindAsync<TEntity>(id);
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        await Task.Run(() => _context.Set<TEntity>().Update(entity));
        return entity;
    }
}
