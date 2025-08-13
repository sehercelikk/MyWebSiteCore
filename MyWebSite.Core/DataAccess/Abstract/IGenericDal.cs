using MyWebSite.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSite.Core.DataAccess.Abstract;

public interface IGenericDal<T> where T: class,IEntity,new()
{
    Task<T> GetByIdAsync(int id);
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null,params Expression<Func<T, object>>[] expressions);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
    Task<bool> AnyAsync(Expression<Func<T, bool>> filter);
}
