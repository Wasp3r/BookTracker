using BookTracker.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BookTracker.ViewModels;

public class BookViewModel : ObservableObject
{
    private string _name;
    private int _id;

    public string Name
    {
        get => _name;
        private set => SetProperty(ref _name, value);
    }

    public int Id => _id;

    public BookViewModel(Book sourceBook)
    {
        if (sourceBook == null) 
            throw new ArgumentNullException(nameof(sourceBook));
        
        Name = sourceBook.Name;
        _id = sourceBook.Id;
    }
}