using Medifii.ReservationService.Entities;
using Microsoft.EntityFrameworkCore;

namespace Medifii.ReservationService.Api.Context
{
	public class ReservationsContext : DbContext
	{
		public ReservationsContext(DbContextOptions options) 
			: base(options) 
		{
			Database.EnsureCreated();
		}

		public DbSet<Reservation> Reservations { get; set; }
	}
}
