using Microsoft.EntityFrameworkCore;
using Shareplus.DataLayer.Models;
using Shareplus.Models;

namespace Shareplus.DataLayer.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

       public DbSet<Admin>Admins { get; set; } 

    public DbSet<Associate> Associates { get; set; } 

        
        public DbSet<PDFile> FileUploads { get; set; } // Ensure this property is correctly named

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PDFile>().ToTable("FileUploads");
        }
    }
}
