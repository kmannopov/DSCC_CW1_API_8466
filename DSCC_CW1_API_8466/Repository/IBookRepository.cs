using DSCC_CW1_MicroservicesAPI_8466.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSCC_CW1_API_8466.Repository
{
    public interface IBookRepository
    {
        void InsertBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int bookId);
        Book GetBookById(int id);
        IEnumerable<Book> GetBooks();

    }
}
