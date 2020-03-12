using Microsoft.EntityFrameworkCore;
using ProjectGoodSamaritan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGoodSamaritan.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<FoundItem> FoundItems { get; set; }
        public DbSet<LostItem> LostItems { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
           
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<LostItem>().HasKey(k=> k.Id);

                modelBuilder.Entity<LostItem>()
                .HasIndex(item => item.ItemName)
                .IsUnique();


            modelBuilder.Entity<FoundItem>().HasKey(k => k.Id);
            modelBuilder.Entity<FoundItem>()
                .HasIndex(fItem => fItem.ItemName)
                .IsUnique();
        }
    }
}
