using System.Windows.Input;
using BookTracker.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BookTracker.ViewModels;

public class NewBookViewModel : ObservableObject
{
    private readonly Book _newBook;
    private Genre _selectedGenre = Genre.Education;
    private string _name;
    private string _author;
    private bool _started;
    private bool _finished;
    private bool _canCreate;
    
    public NewBookViewModel()
    {
        Genres = Enum.GetValues(typeof(Genre));
        NewBook = new()
        {
            StartingDate = DateTime.Today,
            FinishingDate = DateTime.Today
        };
    }

    public Array Genres { get; }

    public Book NewBook
    {
        get => _newBook;
        private init => SetProperty(ref _newBook, value);
    }

    public string Name
    {
        get => _name;
        set
        {
            SetProperty(ref _name, value);
            _newBook.Name = _name;
            UpdateCanCreate();
        }
    }

    public string Author
    {
        get => _author;
        set
        {
            SetProperty(ref _author, value);
            _newBook.Author = _author;
            UpdateCanCreate();
        }
    }
    
    public Genre SelectedGenre
    {
        get => _selectedGenre;
        set
        {
            SetProperty(ref _selectedGenre, value);
            _newBook.Genre = _selectedGenre;
            UpdateCanCreate();
        }
    }

    public bool Started
    {
        get => _started;
        set
        {
            SetProperty(ref _started, value);
            _newBook.Started = value;
        }
    }

    public bool Finished
    {
        get => _finished;
        set
        {
            SetProperty(ref _finished, value);
            _newBook.Finished = value;
        }
    }

    public bool CanCreate
    {
        get => _canCreate;
        set => SetProperty(ref _canCreate, value);
    }

    private void UpdateCanCreate()
    {
        if (string.IsNullOrWhiteSpace(NewBook.Name))
        {
            CanCreate = false;
            return;
        }

        if (string.IsNullOrWhiteSpace(NewBook.Author))
        {
            CanCreate = false;
            return;
        }

        if ((int)SelectedGenre < 0)
        {
            CanCreate = false;
            return;
        }

        CanCreate = true;
    }
}