using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.DAL
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext bookContext;

        public BookRepository(BookContext context)
        {
            bookContext = context;
        }
        public void Delete(int id)
        {
            Book book = bookContext.Books.Find(id);
            bookContext.Books.Remove(book);
        }

        private bool dis = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.dis)
            {
                if(disposing)
                {
                    bookContext.Dispose();
                }    
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Book GetBookbyId(int id)
        {
            return bookContext.Books.Find(id);
        }

        public IEnumerable<Book> GetBooks()
        {
            return bookContext.Books.ToList();
        }

        public void Insert(Book book)
        {
            bookContext.Books.Add(book);
        }

        public void Save()
        {
            bookContext.SaveChanges();
        }

        public void Update(Book book)
        {
            bookContext.Entry(book).State =EntityState.Modified;
        }
    }
}
