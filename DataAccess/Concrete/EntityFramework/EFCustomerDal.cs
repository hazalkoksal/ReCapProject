using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCustomerDal : EFEntityRepositoryBase<Customer, RentACarContext>, ICustomerDal
    {
        public List<CustomerDetailDTO> GetCustomerDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from customer in context.Customers
                             join user in context.Users
                             on customer.UserId equals user.UserId
                             select new CustomerDetailDTO { CustomerId=customer.CustomerId,FirstName=user.FirstName,LastName=user.LastName,CompanyName=customer.CompanyName, FindexPoint=customer.FindexPoint };

                return result.ToList();
            }
        }
    }
}
