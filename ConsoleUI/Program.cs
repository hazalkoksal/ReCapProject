using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //RENTAL
            //RentalManager rentalManager = new RentalManager(new EFRentalDal());

            //Add
            //var result=rentalManager.Add(new Rental { CarId = 2, CustomerId = 5, RentDate = new DateTime(2021,2,13) });
            //Console.WriteLine(result.Message);

            //Detail
            //var result = rentalManager.GetRentalDetails();
            //if(result.Success==true)
            //{
            //    foreach (var rental in result.Data)
            //    {
            //        Console.WriteLine(rental.RentalId + " / " + rental.CarName + " / " + rental.CustomerName + " / " + rental.RentDate + " / " + rental.ReturnDate);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}
        }
    }
}
