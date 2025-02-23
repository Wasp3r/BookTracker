using SQLite;
using SQLiteNetExtensions.Attributes;

namespace BookTracker.Models;

[Table("books")]
public class Book
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    
    public float Rating { get; set; }
    public DateOnly StartingDate { get; set; }
    public DateOnly FinishingDate { get; set; }
    public bool Read { get; set; }
    
    [OneToMany]
    public List<Note> Notes { get; set; } = new();
    
    public string? Name { get; set; }
    public string? Author { get; set; }
}