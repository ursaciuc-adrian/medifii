using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medifii.Common.DataAccess
{
	public class UnitOfWork<TDbContext> : IUnitOfWork<TDbContext>
		where TDbContext : DbContext
	{
		private readonly TDbContext _context;
		private Dictionary<string, object> _repositories;

		public UnitOfWork(TDbContext context)
		{
			_context = context;
		}

		public async Task<int> SaveChangesAsync()
		{
			return await _context.SaveChangesAsync();
		}

		public IRepository<TEntity> Repository<TEntity>() 
			where TEntity : BaseEntity
		{
			if (_repositories == null)
			{
				_repositories = new Dictionary<string, object>();
			}

			var key = $"{typeof(TEntity)}-repository";

			if (!_repositories.ContainsKey(key))
			{
				_repositories.Add(key, new Repository<TDbContext, TEntity>(_context));
			}

			return (IRepository<TEntity>)_repositories[key];
		}
	}
}
