using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks(bool trackChances);
        Book GetBookById (int id, bool trackChanges);
        Book CreateBook (Book book);
        void UpdateBook (Book book);
        void DeleteBook (Book book);

    }
}
