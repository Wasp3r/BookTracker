using BookTracker.Models;

namespace BookTracker.DataAccess;

public interface IBooksRepository
{
    Task<List<Book>> GetAllBooks();
    Task InsertBook(Book book);
    Task UpdateBook(Book book);
    Task DeleteBook(int bookId);
}