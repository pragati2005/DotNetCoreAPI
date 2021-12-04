using BooksAPI.Data;
using BooksAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksAPI.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly Data.BookStoreContext _bookStoreContext;
        public BookRepository(BookStoreContext context)
        {
            _bookStoreContext = context;
        }
        public async Task<List<Book>> GetAllBooks()
        {
            var records = await _bookStoreContext.Book.Select(x => new Book()
            {
                //BookId = x.BookId,
                Title = x.Title,
                Description = x.Description,
                Authorid = x.Authorid
            }).ToListAsync();
            return records;
        }

        public async Task<Book> GetBookById(int bookid)
        {
            var record = await _bookStoreContext.Book.Where(x => x.BookId == bookid).Select(x => new Book()
            {
                BookId = x.BookId,
                Title = x.Title,
                Description = x.Description,
                Authorid = x.Authorid
            }).FirstOrDefaultAsync();
            return record;
        }
        public async Task<int> AddBookAsync(Book bookmodel)
        {
            var book = new Book
            {
                //BookId = bookmodel.BookId,
                Title = bookmodel.Title,
                Description = bookmodel.Description,
                Authorid = bookmodel.Authorid

            };
            _bookStoreContext.Add(book);
            await _bookStoreContext.SaveChangesAsync();
            return book.BookId;
        }
        public async Task<int> UpdateBookAsync(int id, Book bookmodel)
        {
            var book = await _bookStoreContext.Book.FindAsync(id);
            if (book != null)
            {
                book.BookId = bookmodel.BookId;
                book.Title = bookmodel.Title;
                book.Description = bookmodel.Description;
                book.Authorid = bookmodel.Authorid;
            }
            _bookStoreContext.Add(book);
            await _bookStoreContext.SaveChangesAsync();
            return book.BookId;
        }

    }
}
