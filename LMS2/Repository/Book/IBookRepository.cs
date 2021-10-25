using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS2.Models
{
    public interface IBookRepository
    {
        BookCreate GetBook(int Id); //change argument to bookname
        IEnumerable<BookCreate> GetAllBooks();
        BookCreate Add(BookCreate addBook);
        BookCreate Update(BookCreate updateBook);
        BookCreate Delete(int Id);
    }
}
