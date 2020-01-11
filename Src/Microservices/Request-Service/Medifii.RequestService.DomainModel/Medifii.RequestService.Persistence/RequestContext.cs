using Medifii.RequestService.Data.Entities;
using Medifii.RequestService.Persistence.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Medifii.RequestService.Persistence
{
    public class RequestContext : DbContext
    {
        public RequestContext(DbContextOptions<RequestContext> options) : base(options)
        {
        }

        public DbSet<Request> Requests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new RequestMapping().Configure(modelBuilder.Entity<Request>());
        }
    }
}
