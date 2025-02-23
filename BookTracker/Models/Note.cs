namespace BookTracker.Models;

public class Note(string title, string content)
{
    public int Id { get; set; }
    
    public string Title { get; set; } = title;
    public string Content { get; set; } = content;
}