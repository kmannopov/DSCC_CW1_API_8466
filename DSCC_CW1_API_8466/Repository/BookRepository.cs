using DSCC_CW1_MicroservicesAPI_8466.DbContexts;
using DSCC_CW1_MicroservicesAPI_8466.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSCC_CW1_API_8466.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _dbContext;

        public BookRepository(BookContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteBook(int bookId)
        {
            var book = _dbContext.Books.Find(bookId);
            _dbContext.Books.Remove(book);
            Save();
        }

        public Book GetBookById(int bookId)
        {
            var book = _dbContext.Books.Find(bookId);
            _dbContext.Entry(book).Reference(s => s.Genre).Load();
            return book;
        }

        public IEnumerable<Book> GetBooks()
        {
            return _dbContext.Books.Include(s => s.Genre).ToList();
        }

        public void InsertBook(Book book)
        {
            _dbContext.Add(book);
            Save();
        }

        public void UpdateBook(Book book)
        {
            _dbContext.Entry(book).State =  EntityState.Modified;
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
