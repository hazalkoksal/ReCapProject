using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {

            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(CheckIfCarAvaliable(rental.CarId));

            if(result != null)
            {
                return result;
            }
            
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.CarRanted);           
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == rentalId));
        }

        public IDataResult<List<RentalDetailDTO>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDTO>>(_rentalDal.GetRentalDetails());
        }

        private IResult CheckIfCarAvaliable(int carId)
        {
            var result = _rentalDal.GetAll(r => r.CarId == carId && r.ReturnDate == null).Any();
            if(result)
            {
                return new ErrorResult(Messages.CarIsNotAvaliable);
            }
            return new SuccessResult();                
        }
    }
}
