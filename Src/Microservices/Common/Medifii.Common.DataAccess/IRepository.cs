using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Medifii.Common.DataAccess
{
	public interface IRepository<TEntity> where TEntity : BaseEntity
	{
		Task<TEntity> GetByIdAsync(Guid id);

		Task<TEntity> AddAsync(TEntity entity);
		Task<TEntity> UpdateAsync(TEntity entity);
		void Delete(TEntity entity);

		Task<IEnumerable<TEntity>> GetAllAsync();
		Task<IEnumerable<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> predicate);
	}
}
