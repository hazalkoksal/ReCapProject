﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(int rentalId);
        IDataResult<List<RentalDetailDTO>> GetRentalDetails();
        IResult CheckIfCarAvaliable(int carId, DateTime rentDate, DateTime returnDate);
        IResult CheckIfFindexPointEnough(int carId, int customerId);
    }
}
