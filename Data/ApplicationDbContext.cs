using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectGoodSamaritan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGoodSamaritan.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<FoundItem> FoundItems { get; set; }
        public DbSet<LostItem> LostItems { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
           
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //configure lost items
            modelBuilder.Entity<LostItem>()
                .HasKey(k=> k.Id);


            modelBuilder.Entity<LostItem>()
                .HasIndex(item => item.ItemName);

            modelBuilder.Entity<LostItem>()
                .HasOne<AppUser>(c => c.User)
                .WithMany(c => c.LostItems)
                .HasForeignKey(c => c.AppUserId);

            
            //configure found items
            
            modelBuilder.Entity<FoundItem>()
                .HasOne<AppUser>(c => c.User)
                .WithMany(c => c.FoundItems)
                .HasForeignKey(c => c.AppUserId);


            modelBuilder.Entity<FoundItem>()
                .HasKey(k => k.Id);

            modelBuilder.Entity<FoundItem>()
                .HasIndex(fItem => fItem.ItemName);
        }
    }
}
