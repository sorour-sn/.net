using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS2.Models
{
    public class SQLBookRepository : IBookRepository
    {
        private List<BookCreate> _bookList;
        private readonly DatabaseContext context;
        public SQLBookRepository(DatabaseContext context) 
        {
            this.context = context;
        }
        public BookCreate Add(BookCreate addBook)
        {
            //BookCreate newBook = new BookCreate
            //{
            //    BookID = _bookList.Max(a => a.BookID) + 1,
            //////addBook.BookID = context.Books.Max(a => a.BookID) + 1; //here is the problem!!!!!!!!
            //    BookName = addBook.BookName,
            //    Author = addBook.Author,
            //    Publisher = addBook.Publisher,
            //    Image = addBook.Image,
            //    Description = addBook.Description
            //};
            addBook.Stock = false;
            context.Books.Add(addBook);
            context.SaveChanges();
            return addBook;
        }

        public BookCreate Delete(int Id)
        {
            BookCreate book = context.Books.Find(Id);
            if (book != null)
            {
                context.Books.Remove(book);
                context.SaveChanges();
            }
            return book;
        }

        public IEnumerable<BookCreate> GetAllBooks()
        {
            return context.Books;
        }

        public BookCreate GetBook(int Id)
        {
            return context.Books.Find(Id);
        }

        public BookCreate Update(BookCreate updateBook)
        {
            var bBook = context.Books.Attach(updateBook);
            bBook.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return updateBook;
        }
    }
}
