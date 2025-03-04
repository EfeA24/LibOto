using Repositories.UnitOfWork;
using Services.Contracts;

namespace Services.Implementations
{
    public class ServiceManager : IServiceManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private IBookService _bookService;
        private ICategoryService _categoryService;
        private IRentalService _rentalService;
        private IUserService _userService;

        public ServiceManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IBookService BookService => _bookService ??= new BookService(_unitOfWork);
        public ICategoryService CategoryService => _categoryService ??= new CategoryService(_unitOfWork);
        public IRentalService RentalService => _rentalService ??= new RentalService(_unitOfWork);
        public IUserService UserService => _userService ??= new UserService(_unitOfWork);
    }
}