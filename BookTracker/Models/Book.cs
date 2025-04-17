using SQLite;
using SQLiteNetExtensions.Attributes;

namespace BookTracker.Models;

[Table("books")]
public class Book
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    
    public float Rating { get; set; }
    public DateTime StartingDate { get; set; }
    public DateTime FinishingDate { get; set; }
    public bool Started { get; set; }
    public bool Finished { get; set; }
    public Genre Genre { get; set; }
    
    [OneToMany]
    public List<Note> Notes { get; set; } = new();

    public string Name { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
}