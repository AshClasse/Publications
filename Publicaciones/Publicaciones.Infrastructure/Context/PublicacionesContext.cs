using Publicaciones.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Infrastructure.Context
{
    public class PublicacionesContext : DbContext
    {
        public PublicacionesContext(DbContextOptions<PublicacionesContext> options) : base(options)
        {

        }

        public DbSet<Titles> Titles { get; set; }
        public DbSet<RoySched> RoySched { get; set; }
        public DbSet<Pub_Info> Pub_Info { get; set; }
		public DbSet<Publisher> Publisher { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pub_Info>().HasKey(s => s.PubInfoID);
			modelBuilder.Entity<RoySched>().HasKey(s => s.RoySched_ID);
			modelBuilder.Entity<Titles>().HasKey(s => s.Title_ID);
			modelBuilder.Entity<Publisher>().HasKey(e => e.PubID);

			base.OnModelCreating(modelBuilder);
        }
    }
}
