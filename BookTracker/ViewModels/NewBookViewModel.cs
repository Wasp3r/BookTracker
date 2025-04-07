using BookTracker.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BookTracker.ViewModels;

public class NewBookViewModel : ObservableObject
{
    private Book _newBook;
    private Genre _selectedGenre;
    
    public NewBookViewModel()
    {
        Genres = Enum.GetValues(typeof(Genre));
        NewBook = new();
    }

    public Array Genres { get; }

    public Book NewBook
    {
        get => _newBook;
        init => SetProperty(ref _newBook, value);
    }
    
    public Genre SelectedGenre
    {
        get => _selectedGenre;
        set => SetProperty(ref _selectedGenre, value);
    }

    public bool CanCreate => IsBookValid();

    private bool IsBookValid()
    {
        if (string.IsNullOrWhiteSpace(NewBook.Name)) return false;
        if (string.IsNullOrWhiteSpace(NewBook.Author)) return false;

        return true;
    }
}