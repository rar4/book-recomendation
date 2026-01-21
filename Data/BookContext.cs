using bookrec.Models;

using Microsoft.EntityFrameworkCore;

namespace bookrec.Data;

public class BookContext: DbContext
    {
        public DbSet<SimilarBookDto> SimilarBooks { get; set; }
    

    public DbSet<UserRatings> UserRatings {get; set;}

    public DbSet<Book> Book {get; set;}

    public DbSet<Rating> Rating {get; set;}
    public DbSet<Similarity> Similarity {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=Data/books.db");
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    //UserRatings

    modelBuilder.Entity<UserRatings>( entity =>
    {
        entity.ToTable("UserRatings");
        entity.HasKey(u => u.BookId);

        entity.Property(u => u.BookId).HasColumnName("book_id");
        entity.Property(u => u.Rating).HasColumnName("rating");

    });

    // Book
        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable("Book");
            entity.HasKey(b => b.Id);

            entity.Property(b => b.Id).HasColumnName("id");
            entity.Property(b => b.Isbn).HasColumnName("isbn");
        });

        // Rating
        modelBuilder.Entity<Rating>(entity =>
        {
            entity.ToTable("Rating");
            entity.HasKey(r => new { r.UserId, r.BookId });

            entity.Property(r => r.UserId).HasColumnName("user_id");
            entity.Property(r => r.BookId).HasColumnName("book_id");
            entity.Property(r => r.BookRating).HasColumnName("rating");
        });

        // Similarity
        modelBuilder.Entity<Similarity>(entity =>
        {
            entity.ToTable("Similarity");
            entity.HasKey(s => new { s.BookId1, s.BookId2 });

            entity.Property(s => s.BookId1).HasColumnName("book_id1");
            entity.Property(s => s.BookId2).HasColumnName("book_id2");
            entity.Property(s => s.BookSimilarity).HasColumnName("similarity");
        });
        
    modelBuilder.Entity<Rating>().HasKey(br => new { br.BookId, br.UserId });
    modelBuilder.Entity<Similarity>().HasKey(sim => new {sim.BookId1, sim.BookId2});
    modelBuilder.Entity<SimilarBookDto>().HasNoKey();
}

}