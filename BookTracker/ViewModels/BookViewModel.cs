using BookTracker.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BookTracker.ViewModels;

public class BookViewModel : ObservableObject
{
    private readonly int _id;
    private string _name;
    private string _author;
    private float _rating;
    private DateTime _staringDate;
    private DateTime _finishingDate;
    private bool _started;
    private bool _finished;
    private Genre _genre;
    private List<Note> _notes;

    public int Id => _id;
    
    public string Name
    {
        get => _name;
        private set => SetProperty(ref _name, value);
    }

    public string Author
    {
        get => _author;
        set => SetProperty(ref _author, value);
    }

    public float Rating
    {
        get => _rating;
        set => SetProperty(ref _rating, value);
    }

    public bool Started
    {
        get => _started;
        set => SetProperty(ref _started, value);
    }

    public bool Finished
    {
        get => _finished;
        set => SetProperty(ref _finished, value);
    }

    public DateTime StartingDate
    {
        get => _staringDate;
        set => SetProperty(ref _staringDate, value);
    }

    public DateTime FinishingDate
    {
        get => _finishingDate;
        set => SetProperty(ref _finishingDate, value);
    }

    public Genre Genre
    {
        get => _genre;
        set => SetProperty(ref _genre, value);
    }

    public List<Note> Notes
    {
        get => _notes;
        set => SetProperty(ref _notes, value);
    }

    public BookViewModel(Book sourceBook)
    {
        if (sourceBook == null) 
            throw new ArgumentNullException(nameof(sourceBook));
        
        _id = sourceBook.Id;
        Name = sourceBook.Name;
        Author = sourceBook.Author;
        Rating = sourceBook.Rating;
        Genre = sourceBook.Genre;
        StartingDate = sourceBook.StartingDate;
        FinishingDate = sourceBook.FinishingDate;
        Started = sourceBook.Started;
        Finished = sourceBook.Finished;
        Notes = sourceBook.Notes;
    }
}