namespace BookTracker.Models;

public class Book (string name, string author)
{
    public int Id { get; set; }
    public float Rating { get; set; }
    public DateOnly StartingDate { get; set; }
    public DateOnly FinishingDate { get; set; }
    public bool Read { get; set; }
    public List<Note> Notes { get; set; } = new();
    
    public string Name { get; set; } = name;
    public string Author { get; set; } = author;
}