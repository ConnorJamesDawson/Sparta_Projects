using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApp.DataAccess.Repository.IRepository;

public interface IRepository<T> where T : class
{
    void Add(T entity);
    void AddRange(IEnumerable<T> entity);
    void Delete(T entity);
    void DeleteRange(IEnumerable<T> entity);
    T GetByIdFirstOrDefault(Expression<Func<T, bool>>? filter = null, 
        string? includeProperties = null);
    IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null,
				Func<IQueryable<T>, IOrderedQueryable<T>>? orderby = null,
                string includeProperties = null);

}
