using ApiProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=AK;initial catalog=RickAndMortDb;integrated security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            // Configure the one-to-many relationship between Location and Character entities
            modelBuilder.Entity<Location>()
                .HasMany(l => l.Residents)
                .WithOne(c => c.Origin)
                .HasForeignKey(c => c.OriginId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Location> Locations { get; set; }



    }
}
