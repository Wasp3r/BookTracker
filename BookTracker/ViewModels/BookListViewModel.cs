using BookTracker.DataAccess;
using BookTracker.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BookTracker.ViewModels;

public class BookListViewModel : ObservableObject
{
    private readonly IBooksRepository _booksRepository;
    private List<BookViewModel> _books;
    private BookViewModel _selectedBook;

    public BookListViewModel(IBooksRepository booksRepository)
    {
        _booksRepository = booksRepository;
    }

    public List<BookViewModel> Books
    {
        get => _books;
        set => SetProperty(ref _books, value);
    }

    public BookViewModel SelectedBook
    {
        get => _selectedBook;
        set => SetProperty(ref _selectedBook, value);
    }

    public async Task RefreshBooks()
    {
        var books = await _booksRepository.GetAllBooks();
        var collection = new List<BookViewModel>();
        foreach (var book in books)
        {
            collection.Add(new BookViewModel(book));
        }

        Books = collection;
    }
}