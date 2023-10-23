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

        public DbSet<Authors> Authors { get; set; }
        public DbSet<TitleAuthor> TitleAuthor { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.Entity<Authors>().HasKey(au => au.Au_ID);
            modelBuilder.Entity<TitleAuthor>().HasKey(au => new { au.Title_ID, au.Au_ID });
			base.OnModelCreating(modelBuilder);
		}
	}
}