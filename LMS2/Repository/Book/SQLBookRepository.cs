using LMS2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS2.Repository.Book
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
            addBook.Stock = false;
            context.Books.Add(addBook);
            context.SaveChanges();
            return addBook;
        }

        public BookCreate Delete(string Id)
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

        public BookCreate GetBook(string Id)
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
