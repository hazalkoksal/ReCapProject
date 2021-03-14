using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCarDal : EFEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDTO> GetCarDetails()
        {
            using(RentACarContext context = new RentACarContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             join color in context.Colors                            
                             on car.ColorId equals color.ColorId
                             select new CarDetailDTO { CarId = car.CarId, CarName=car.CarName, BrandName = brand.BrandName, ColorName = color.ColorName, ModelYear=car.ModelYear, DailyPrice = car.DailyPrice, Description=car.Description };

                return result.ToList();
            }
        }
    }
}
