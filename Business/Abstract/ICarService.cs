using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetByBrandId(int brandId);
        IDataResult<List<Car>> GetByColorId(int colorId);
        IDataResult<Car> GetById(int carId);
        IDataResult<List<CarDetailDTO>> GetCarDetails();
        IDataResult<List<CarDetailDTO>> GetCarDetailsById(int carId);
        IDataResult<List<CarDetailDTO>> GetCarDetailsByBrandId(int brandId);
        IDataResult<List<CarDetailDTO>> GetCarDetailsByColorId(int colorId);
        IDataResult<List<CarDetailDTO>> GetCarDetailsByBrandIdColorId(int brandId,int colorId);
    }
}
