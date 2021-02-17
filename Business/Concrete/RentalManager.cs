using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
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
            var rnt = _rentalDal.Get(r => r.CarId == rental.CarId && r.ReturnDate == null);

            if(rnt!=null)
            {
                return new ErrorResult(Messages.CarIsNotAvaliable);               
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
    }
}
