using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IRentalRepository Rental { get; }
        ICategoryRepository Category { get; }
        IUserRepository User { get; }
        IBookRepository Book { get; }
    }
}
