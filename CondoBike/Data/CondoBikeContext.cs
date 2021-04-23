using CondoBike.Model;
using Microsoft.EntityFrameworkCore;


namespace CondoBike.Data
{
    public class CondoBikeContext : DbContext
    {
        DbSet<Bicycle> Bicycles {get ; set;}
        DbSet<Owner> Owners {get; set;}
        DbSet<BicycleStorage> BicycleStorages {get; set;}

        public CondoBikeContext()
        {

            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                optionsBuilder.UseSqlServer("");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
        

    }
}