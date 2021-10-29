using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMS2.Models;

namespace LMS2.Repository.Book
{
    public interface IBookRepository
    {
        BookCreate GetBook(int Id); 
        IEnumerable<BookCreate> GetAllBooks();
        BookCreate Add(BookCreate addBook);
        BookCreate Update(BookCreate updateBook);
        BookCreate Delete(int Id);
    }
}
