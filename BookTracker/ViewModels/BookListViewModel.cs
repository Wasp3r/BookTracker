using System.Collections.ObjectModel;
using BookTracker.DataAccess;
using BookTracker.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BookTracker.ViewModels;

public class BookListViewModel : ObservableObject
{
    private readonly IBooksRepository _booksRepository;
    private ObservableCollection<BookViewModel> _books;
    private BookViewModel _selectedBook;

    public BookListViewModel(IBooksRepository booksRepository)
    {
        _booksRepository = booksRepository;
        RemoveBookCommand = new AsyncRelayCommand<BookViewModel>(DeleteBook);
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

    public IAsyncRelayCommand RemoveBookCommand { get; set; }

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

    public async Task<BookViewModel> CreateBook(Book newBook)
    {
        await _booksRepository.InsertBook(newBook);
        var newBookViewModel = new BookViewModel(newBook);
        Books.Add(newBookViewModel);
        return newBookViewModel;
    }

    private async Task DeleteBook(BookViewModel? bookToRemove)
    {
        if (bookToRemove == null) return;
        await _booksRepository.DeleteBook(bookToRemove.Id);
        Books.Remove(bookToRemove);
    }
}