using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRentalRepository : IRepositoryBase<Rental>
    {
        IQueryable<Rental> GetAllRentals(bool trackChanges);
        Rental GetRentalById(int rentalId, bool trackChanges);
        Rental GetRentalByUser (int userId, bool trackChanges);
        void CreateRental(Rental rental);
        void UpdateRental(Rental rental);
        void DeleteRental(Rental rental);
    }
}
