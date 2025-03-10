using BookTracker.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BookTracker.ViewModels;

public class BookViewModel : ObservableObject
{
    private string _name;

    public string Name
    {
        get => _name;
        private set => SetProperty(ref _name, value);
    }

    public BookViewModel(Book sourceBook)
    {
        if (sourceBook == null) 
            throw new ArgumentNullException(nameof(sourceBook));
        
        Name = sourceBook.Name;
    }
}