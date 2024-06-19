using Microsoft.EntityFrameworkCore;
using Shareplus.DataLayer.Models;

namespace Shareplus.DataLayer.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<PDFile> FileUploads { get; set; } // Ensure this property is correctly named

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PDFile>().ToTable("FileUploads");
        }
    }
}
