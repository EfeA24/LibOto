using Entities.Models;
using Services.Contracts;
using Repositories.UnitOfWork;

namespace Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Book CreateBook(Book book)
        {
            _unitOfWork.Book.CreateBook(book);
            _unitOfWork.Save();
            return book;
        }

        public void DeleteBook(Book book)
        {
            _unitOfWork.Book.DeleteBook(book);
            _unitOfWork.Save();
        }

        public IEnumerable<Book> GetAllBooks(bool trackChanges)
        {
            return _unitOfWork.Book.GetAllBooks(trackChanges).ToList();
        }

        public Book GetBookById(int id, bool trackChanges)
        {
            return _unitOfWork.Book.GetBookById(id, trackChanges);
        }

        public void UpdateBook(Book book)
        {
            _unitOfWork.Book.UpdateBook(book);
            _unitOfWork.Save();
        }
    }
}