using System.Collections.ObjectModel;
using BookTracker.DataAccess;
using BookTracker.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BookTracker.ViewModels;

public class BookListViewModel : ObservableObject
{
    private readonly IBooksRepository _booksRepository;
    private ObservableCollection<BookViewModel> _books;
    private BookViewModel _selectedBook;

    public BookListViewModel(IBooksRepository booksRepository)
    {
        _booksRepository = booksRepository;
    }

    public ObservableCollection<BookViewModel> Books
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
        var collection = new ObservableCollection<BookViewModel>();
        foreach (var book in books)
        {
            collection.Add(new BookViewModel(book));
        }

        Books = collection;
    }

    public async Task CreateBook(Book newBook)
    {
        await _booksRepository.InsertBook(newBook);
        Books.Add(new BookViewModel(newBook));
    }

    public async Task DeleteBook(BookViewModel bookToRemove)
    {
        await _booksRepository.DeleteBook(bookToRemove.Id);
        Books.Remove(bookToRemove);
    }
}