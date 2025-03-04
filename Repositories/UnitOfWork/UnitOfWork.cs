using Entities;
using Repositories.Contracts;
using Repositories.EfCore;

namespace Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IBookRepository _bookRepository;
        private ICategoryRepository _categoryRepository;
        private IRentalRepository _rentalRepository;
        private IUserRepository _userRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IBookRepository Book => _bookRepository ??= new BookRepository(_context);
        public ICategoryRepository Category => _categoryRepository ??= new CategoryRepository(_context);
        public IRentalRepository Rental => _rentalRepository ??= new RentalRepository(_context);
        public IUserRepository User => _userRepository ??= new UserRepository(_context);

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}