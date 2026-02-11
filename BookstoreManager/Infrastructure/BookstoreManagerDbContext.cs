using BookstoreManager.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstoreManager.Infrastructure;

public class BookstoreManagerDbContext : DbContext
{
    public DbSet<Book> Books { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=/Volumes/KINGSTON/Developer/dotnet/BookstoreManager/Database/bookstore.db");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .Property(b => b.Genre)
            .HasConversion<string>(); 
    }
}