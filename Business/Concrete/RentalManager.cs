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
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.CarRanted);           
        }

        public IResult CheckIfCarAvaliable(int carId, DateTime rentDate, DateTime returnDate)
        {
            var rentals = _rentalDal.GetAll(r => r.CarId == carId) != null ? _rentalDal.GetAll(r => r.CarId == carId) : null;

            if(rentals != null)
            {
                foreach (var rental in rentals)
                {
                    if ((rental.RentDate <= rentDate && rental.ReturnDate >= rentDate) || (rental.RentDate <= returnDate && rental.ReturnDate >= returnDate) || (rentDate <= rental.RentDate && returnDate >= rental.ReturnDate))
                    {
                        return new ErrorResult(Messages.CarNotAvaliable);
                    }
                }

                return new SuccessResult(Messages.CarAvaliable);
            }

            return new SuccessResult(Messages.CarAvaliable);
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
