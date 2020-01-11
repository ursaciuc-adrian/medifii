using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Medifii.Common.DataAccess
{
	public interface IUnitOfWork<TDbContext>
		where TDbContext : DbContext
	{
		Task<int> SaveChangesAsync();

		IRepository<TEntity> Repository<TEntity>()
			where TEntity : BaseEntity;
	}
}
