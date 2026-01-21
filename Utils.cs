using Microsoft.EntityFrameworkCore;
using bookrec.Data;
using System.Text.Json;
using bookrec.Models;
namespace bookrec;




public class Utils(BookContext context)
{
    readonly BookContext _db = context;

    public void SaveRating(int rating, int bookid)
    {
        try
        {
        _db.UserRatings.Add(new UserRatings{BookId = bookid, Rating = (byte) rating});
        _db.SaveChanges();
        }
        catch (Microsoft.EntityFrameworkCore.DbUpdateException)
        {
            Console.WriteLine("error, dublicates!!!");
        }

        
    }

    public void FillSimilarityTable()
    {
        _db.Database.ExecuteSqlRaw(
            File.ReadAllText("Data/SQLScripts/ComputeSimilarity.sql")
        );
    }

    public VolumeInfo IsbnLookup(string isbn)
    {
        using var http = new HttpClient();
        string url = $"https://www.googleapis.com/books/v1/volumes?q=isbn:{isbn}&fields=items(volumeInfo(title,authors,publishedDate,description,imageLinks/thumbnail,industryIdentifiers),searchInfo/textSnippet)";

        try
        {
            HttpResponseMessage response = http.GetAsync(url).GetAwaiter().GetResult();
            response.EnsureSuccessStatusCode();

            string JSONString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            GoogleBooksResponse book = JsonSerializer.Deserialize<GoogleBooksResponse>(JSONString);

            return book.Items[0].VolumeInfo;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Network error {ex}");
            
        }

        VolumeInfo empty = new();

        return empty;



    }

    public long[] GetRecomendedBookIsbnAndId()
    {
        int bookId;

        
        if (!_db.UserRatings.Where(u => u.Rating > 3).Any())
        {
            Random random = new();

            bookId = random.Next(1,10000);


        }
        else
        {
            
        string sql = File.ReadAllText("Data/SQLScripts/RecomendBook.sql");

        SimilarBookDto result =  _db.SimilarBooks.FromSqlRaw(sql).First();

        bookId = result.SimilarBookId;

        }


        
        
        return [_db.Book.Where(b => b.Id == bookId).First().Isbn, bookId];




    }

   
   


}