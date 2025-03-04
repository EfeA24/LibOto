using Entities.Models;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore
{
    public class RentalRepository : RepositoryBase<Rental>, IRentalRepository
    {
        public RentalRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void CreateRental(Rental rental)
        {
            Create(rental);
        }

        public void DeleteRental(Rental rental)
        {
            Delete(rental);
        }

        public IQueryable<Rental> GetAllRentals(bool trackChanges)
        {
            return GetAll(trackChanges)
                .OrderBy(x => x.RentalDate);
        }

        public Rental GetRentalById(int rentalId, bool trackChanges)
        {
            return GetByCondition(x => x.RentId == rentalId, trackChanges)
                .SingleOrDefault();
        }

        public Rental? GetRentalByUser(string userName, bool trackChanges)
        {
            var user = GetByCondition(x => x.User.FullName == userName, trackChanges)
                .Select(x => x.User)
                .FirstOrDefault();

            return user != null
                ? GetByCondition(x => x.UserId == user.Id, trackChanges).FirstOrDefault()
                : null;
        }


        public void UpdateRental(Rental rental)
        {
            Update(rental);
        }
    }
}
