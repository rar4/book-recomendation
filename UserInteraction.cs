using System;
using bookrec.Data;
using bookrec.Models;
using bookrec;
namespace bookrec;


static class UserInteraction
{


   

    static public IResult FeedEndpoint(Utils utils)
    {
        long[] isbn_and_id = utils.GetRecomendedBookIsbnAndId();

        var BookData = utils.IsbnLookup(isbn_and_id[0].ToString());

        BookData.BookId = (int) isbn_and_id[1];

        Console.WriteLine(BookData.BookId);


        return Results.Json(BookData);
    }

    static public void RateEndpoint(Utils utils, int rating, int id)
    {
        utils.SaveRating(rating, id);
    }

    static public void DbErrorEndpoint(Utils utils)
    {
        utils.SaveRating(3, (int) utils.GetRecomendedBookIsbnAndId()[1]);
    }
    




}
