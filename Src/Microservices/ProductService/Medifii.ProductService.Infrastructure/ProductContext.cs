using System;
using System.Collections.Generic;
using System.Text;
using Medifii.ProductService.Infrastructure.Entities;
using Medifii.ProductService.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Medifii.ProductService.Infrastructure
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions options) : base(options)
        { 
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new ProductMapping().Configure(modelBuilder.Entity<Product>());
        }
    }
}
