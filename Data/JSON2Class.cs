using System.Collections.Generic;
using System.Text.Json.Serialization;

public class GoogleBooksResponse
{
    [JsonPropertyName("items")]
    public List<BookItem> Items { get; set; }

}

public class BookItem
{
    [JsonPropertyName("volumeInfo")]
    public VolumeInfo VolumeInfo { get; set; }

}

public class VolumeInfo
{
    [JsonPropertyName("bookId")]
    public int BookId {get; set;}

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("authors")]
    public List<string> Authors { get; set; }

    [JsonPropertyName("publishedDate")]
    public string PublishedDate { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("imageLinks")]
    public ImageLink ImageLink { get; set; }

    [JsonPropertyName("industryIdentifiers")]
    public List<IndustryIdentifier> IndustryIdentifiers {get; set;}
}

public class ImageLink
{
    [JsonPropertyName("thumbnail")]
    public string Thumbnail { get; set; }
}




public class IndustryIdentifier
{
    [JsonPropertyName("type")]
    public string Type { get; set; }
    [JsonPropertyName("identifier")]
    public string Identifier { get; set; }
}
