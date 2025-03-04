using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IRentalService
    {
        IEnumerable<Rental> GeAlltRentedBooks(bool trackChanges);
        Rental GetRentalById(int id);
        Rental GetRentalByUser(string FullName);
        Rental CreateRental (Rental rental);
        void UpdateRental(Rental rental);
        void DeleteRental(Rental rental);
    }
}
