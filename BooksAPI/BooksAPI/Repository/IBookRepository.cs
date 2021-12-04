using BooksAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksAPI.Repository
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBooks();
         Task<Book> GetBookById(int bookid);
         Task<int> AddBookAsync(Book bookmodel);
        Task <int> UpdateBookAsync(int id, Book bookmodel);
    }
}