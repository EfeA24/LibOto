using Repositories.Contracts;
using System;

namespace Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository Book { get; }
        ICategoryRepository Category { get; }
        IRentalRepository Rental { get; }
        IUserRepository User { get; }
        void Save();
    }
}