using  Microsoft.EntityFrameworkCore;
using BookManagementAPI.Models;

namespace BookManagementAPI.DatabaseContext
{
        public class ApplicationDbContext  : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        private void OneToManyRelationshipConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Publisher>()
            .HasMany(c => c.Books)
            .WithOne(s => s.Publisher)
            .IsRequired();
        }
        
    }

}