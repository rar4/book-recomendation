using bookrec.Models;

using Microsoft.EntityFrameworkCore;

namespace bookrec.Data;

public class BookContext: DbContext
{
    public DbSet<Book> Book {get; set;}

    public DbSet<Rating> Rating {get; set;}
    public DbSet<Similarity> Similarity {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=Data/books.db");
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Rating>().HasKey(br => new { br.BookId, br.UserId });
    modelBuilder.Entity<Similarity>().HasKey(sim => new {sim.BookId1, sim.BookId2});
}

}