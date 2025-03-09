using BookTracker.DataAccess;
using BookTracker.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BookTracker.ViewModels;

public class BookListViewModel : ObservableObject
{
    private readonly IBooksRepository _booksRepository;
    private List<Book> _books;
    private Book _selectedBook;

    public BookListViewModel(IBooksRepository booksRepository)
    {
        _booksRepository = booksRepository;
    }

    public List<Book> Books
    {
        get => _books;
        set => SetProperty(ref _books, value);
    }

    public Book SelectedBook
    {
        get => _selectedBook;
        set => SetProperty(ref _selectedBook, value);
    }

    public async Task RefreshBooks()
    {
        Books = await _booksRepository.GetAllBooks();
    }
}