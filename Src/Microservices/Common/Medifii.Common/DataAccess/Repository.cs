using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Medifii.Common.DataAccess
{
	public class Repository<TDbContext, TEntity> : IRepository<TEntity>
		where TDbContext : DbContext
		where TEntity : BaseEntity
	{
		protected TDbContext Context;

		public Repository(TDbContext context)
		{
			Context = context;
		}

		public async Task<TEntity> GetByIdAsync(Guid id)
		{
			return await Context.Set<TEntity>().FindAsync(id);
		}

		public async Task<TEntity> AddAsync(TEntity entity)
		{
			await Context.Set<TEntity>().AddAsync(entity);

			return entity;
		}

		public async Task<TEntity> UpdateAsync(TEntity entity)
		{
			var entry = Context.Entry(entity);
			entry.State = EntityState.Modified;

			return await Task.FromResult(entry.Entity);
		}

		public void Delete(TEntity entity)
		{
			Context.Set<TEntity>().Remove(entity);
		}

		public async Task<IEnumerable<TEntity>> GetAllAsync()
		{
			return await Context.Set<TEntity>().ToListAsync();
		}

		public async Task<IEnumerable<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return await Context.Set<TEntity>().Where(predicate).ToListAsync();
		}
	}
}
