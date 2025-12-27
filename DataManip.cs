using Microsoft.EntityFrameworkCore;
using System;
using static System.Math;
using bookrec.Data;
using bookrec.Models;
namespace bookrec.DataManip;




public class DataManip
{
    public DataManip()
    {
        Console.WriteLine("IN data mainp");

    }


    public double CosineSimilarity(long book1, long book2)
    {
        int[] ratings1 = { };
        int[] ratings2 = { };

        double dot = 0;
        double magnitude1 = 0;
        double magnitude2 = 0;

        //TODO: Implement db interaction
        //TODO: take 15 ratings from each book

        for (int i = 0; i < 10; i++)
        {
            dot += ratings1[i] * ratings2[i];
            magnitude1 += ratings1[i] * ratings1[i];
            magnitude2 += ratings2[i] * ratings2[i];
        }

        magnitude1 = Math.Sqrt(magnitude1);
        magnitude2 = Math.Sqrt(magnitude2);

        return dot / (magnitude1 * magnitude2);





    }

    public string Test()
    {
        using BookContext context = new BookContext();

        var book = context.Book.OrderBy(a => a.Id).FirstOrDefault();

        return $"{book.Isbn}";

    }


}