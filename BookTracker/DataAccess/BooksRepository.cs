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
        var result = await _connection.InsertAsync(book);
        if (result != 1)
        {
            // TODO: Logging system could be implemented
            Console.WriteLine("Failed to insert new book");
            return;
        }

        book.Id = await _connection.ExecuteScalarAsync<int>("SELECT last_insert_rowid();");
    }

    public async Task UpdateBook(Book book)
    {
        await Initialize();
        await _connection.UpdateAsync(book);
    }

    public async Task DeleteBook(int bookId)
    {
        await Initialize();
        try
        {
            var bookToRemove = await _connection.Table<Book>().FirstOrDefaultAsync(x => x.Id == bookId);
            if (bookToRemove == null) return;
            await _connection.DeleteAsync(bookToRemove);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}