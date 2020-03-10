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
            Console.WriteLine(options.ToString());
        }
    }
}
