using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageCountOfCarCorrect(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;

            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            FileHelper.Delete(carImage.ImagePath);

            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(carId));
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = FileHelper.Update(_carImageDal.Get(i=>i.ImageId == carImage.ImageId).ImagePath,file);
            carImage.Date = DateTime.Now;

            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        private IResult CheckIfImageCountOfCarCorrect(int carId)
        {
            var result = _carImageDal.GetAll(i=>i.CarId == carId).Count;

            if (result > 5)
            {
                return new ErrorResult(Messages.ImageCountOfCarError);
            }

            return new SuccessResult();
        }

        private List<CarImage> CheckIfCarImageNull(int carId)
        {
            var result = _carImageDal.GetAll(i => i.CarId == carId).Any();

            if(!result)
            {
                string path = @"\Images\logo.jpg";
                return new List<CarImage> { new CarImage { ImageId=1,CarId=carId,ImagePath=path,Date=DateTime.Now} };
            }

            return _carImageDal.GetAll(i => i.CarId == carId);
        }
    }
}
