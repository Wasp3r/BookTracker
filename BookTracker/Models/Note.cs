using SQLite;
using SQLiteNetExtensions.Attributes;

namespace BookTracker.Models;

[Table("notes")]
public class Note
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    
    [ForeignKey(typeof(Book))]
    public int BookKey { get; set; }
    
    public string? Title { get; set; }
    public string? Content { get; set; }
}