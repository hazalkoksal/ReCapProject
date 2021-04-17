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

            carImage.CarImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;

            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            FileHelper.Delete(carImage.CarImagePath);
            _carImageDal.Delete(carImage);

            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            return GetCarImages(carId);
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.CarImagePath = FileHelper.Update(carImage.CarImagePath,file);
            carImage.Date = DateTime.Now;

            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.CarImageId == carImageId));
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

        private IDataResult<List<CarImage>> GetCarImages(int carId)
        {
            var result = _carImageDal.GetAll(i => i.CarId == carId).Any();

            if (!result)
            {
                string path = @"\Uploads\logo.jpg";

                List<CarImage> carImages = new List<CarImage>();
                carImages.Add(new CarImage { CarId = carId, CarImagePath = path, Date = DateTime.Now });

                return new SuccessDataResult<List<CarImage>>(carImages);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(i => i.CarId == carId).ToList());
        }
    }
}
