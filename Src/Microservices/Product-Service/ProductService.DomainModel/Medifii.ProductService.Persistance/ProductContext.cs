using Medifii.ProductService.Data.Entities;
using Medifii.ProductService.Persistence.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Medifii.ProductService.Persistence
{
	public class ProductContext : DbContext
	{
		public ProductContext(DbContextOptions<ProductContext> options) : base(options)
		{
			Database.EnsureCreated();
		}

		public DbSet<Product> Products { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			new ProductMapping().Configure(modelBuilder.Entity<Product>());
		}
	}
}
