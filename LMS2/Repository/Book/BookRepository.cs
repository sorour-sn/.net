using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS2.Models
{
    public class BookRepository : IBookRepository
    {
        private List<BookCreate> _bookList;

        public BookCreate Add(BookCreate addBook)
        {
            addBook.BookID = _bookList.Max(a => a.BookID)+1;
            _bookList.Add(addBook);
            return addBook;
        }

        public BookCreate Delete(int Id)
        {
            BookCreate deleteBook = _bookList.FirstOrDefault(a => a.BookID == Id);
            if (deleteBook != null)
            {
                _bookList.Remove(deleteBook);
            }
            return deleteBook;
        }

        public IEnumerable<BookCreate> GetAllBooks()
        {
            return _bookList;
        }

        public BookCreate GetBook(int Id)
        {
            return _bookList.FirstOrDefault(a => a.BookID == Id);
        }

        public BookCreate Update(BookCreate updateBook)
        {
            BookCreate bookChanges = _bookList.FirstOrDefault(a => a.BookID == updateBook.BookID);
            if (bookChanges != null)
            {
                bookChanges.Author = updateBook.Author;
                bookChanges.Publisher = updateBook.Publisher;
                bookChanges.Description = updateBook.Description;
                bookChanges.BookName = updateBook.BookName;
                bookChanges.Image = updateBook.Image;

            }
            return bookChanges;
        }
    }
}
