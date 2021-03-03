using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.DAL
{
    public interface IBookRepository: IDisposable
    {
        IEnumerable<Book> GetBooks();
        Book GetBookbyId(int id);
        void Insert(Book book);
        void Delete(int id);
        void Update(Book book);

        void Save();


    }
}
