using System.ComponentModel.DataAnnotations;

namespace bookrec.Models;

public class UserRatings
{
    [Key]
    public long BookId {get; set;}
    public byte Rating {get; set;}
}