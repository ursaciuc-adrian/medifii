﻿using Medifii.ReservationService.Entities;
using Microsoft.EntityFrameworkCore;

namespace Medifii.ReservationService.Api.Context
{
	public class ReservationsContext : DbContext
	{
		public ReservationsContext(DbContextOptions<ReservationsContext> options) 
			: base(options) 
		{ 

		}

		public DbSet<Reservation> Reservations { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}