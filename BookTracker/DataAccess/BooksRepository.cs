using BookTracker.Models;
using BookTracker.ViewModels;
using SQLite;

namespace BookTracker.DataAccess;

public class BooksRepository : IBooksRepository
{
    private readonly string _dbPath;
    
    private ISQLiteAsyncConnection? _connection;

    public BooksRepository(string dbPath)
    {
        _dbPath = dbPath;
    }

    private async Task Initialize()
    {
        if (_connection != null) return;
        _connection = new SQLiteAsyncConnection(_dbPath);
        await _connection.CreateTableAsync<Book>();
        await _connection.CreateTableAsync<Note>();
    }
    
    public async Task<List<Book>> GetAllBooks()
    {
        await Initialize();
        return await _connection.Table<Book>().ToListAsync();
    }

    public async Task InsertBook(Book book)
    {
        await Initialize();
        // TODO: Figure a way to get the ID of the newly created book
        book.Id = await _connection.InsertAsync(book);
    }

    public async Task UpdateBook(Book book)
    {
        await Initialize();
        await _connection.UpdateAsync(book);
    }

    public async Task DeleteBook(int bookToRemove)
    {
        await Initialize();
        await _connection.DeleteAsync<int>(bookToRemove);
    }
}