using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void CreateBook(Book book)
        {
            Create(book);
        }

        public void DeleteBook(Book book)
        {
            Delete(book);
        }

        public IQueryable<Book> GetAllBooks(bool trackChanges)
        {
            return GetAll(trackChanges)
                .OrderBy(b => b.Title);
        }

        public Book GetBookById(int bookId, bool trackChanges)
        {
            return GetByCondition(b => b.BookId.Equals(bookId), trackChanges)
                .SingleOrDefault();
        }

        public void UpdateBook(Book book)
        {
            Update(book);
        }
    }
}
