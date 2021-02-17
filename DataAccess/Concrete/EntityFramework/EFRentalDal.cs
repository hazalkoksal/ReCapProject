using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFRentalDal : EFEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDTO> GetRentalDetails()
        {
            using(RentACarContext context = new RentACarContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars
                             on rental.CarId equals car.CarId
                             join customer in context.Customers
                             on rental.CustomerId equals customer.CustomerId
                             join user in context.Users
                             on customer.UserId equals user.UserId
                             select new RentalDetailDTO { RentalId = rental.RentalId, CarName = car.CarName, CustomerName = user.FirstName + " " + user.LastName, RentDate = rental.RentDate, ReturnDate = rental.ReturnDate };

                return result.ToList();
            }
        }
    }
}
