using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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
