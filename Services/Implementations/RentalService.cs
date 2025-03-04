using Entities.Models;
using Services.Contracts;
using Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Implementations
{
    public class RentalService : IRentalService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RentalService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Rental CreateRental(Rental rental)
        {
            _unitOfWork.Rental.CreateRental(rental);
            _unitOfWork.Save();
            return rental;
        }

        public void DeleteRental(Rental rental)
        {
            _unitOfWork.Rental.DeleteRental(rental);
            _unitOfWork.Save();
        }

        public IEnumerable<Rental> GeAlltRentedBooks(bool trackChanges)
        {
            return _unitOfWork.Rental.GetAllRentals(trackChanges).ToList();
        }

        public Rental GetRentalById(int id)
        {
            return _unitOfWork.Rental.GetRentalById(id, trackChanges: false);
        }

        public Rental GetRentalByUser(string fullName)
        {
            return _unitOfWork.Rental.GetRentalByUser(fullName, trackChanges: false);
        }

        public void UpdateRental(Rental rental)
        {
            _unitOfWork.Rental.UpdateRental(rental);
            _unitOfWork.Save();
        }
    }
}