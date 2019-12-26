using Medifii.PharmacyService.Data.Entities;
using Medifii.PharmacyService.Persistence.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Medifii.PharmacyService.Persistence
{
    public class PharmacyContext : DbContext
    {
        public PharmacyContext(DbContextOptions<PharmacyContext> options) : base(options) { }

        public DbSet<Pharmacy> Pharmacies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new PharmacyMapping().Configure(modelBuilder.Entity<Pharmacy>());
        }
    }
}
