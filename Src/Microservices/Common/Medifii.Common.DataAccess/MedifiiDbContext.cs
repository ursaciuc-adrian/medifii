using Microsoft.EntityFrameworkCore;

namespace Medifii.Common.DataAccess
{
	public class MedifiiDbContext : DbContext
	{
		protected MedifiiDbContext(DbContextOptions options)
			: base(options)
		{
		}
	}
}
