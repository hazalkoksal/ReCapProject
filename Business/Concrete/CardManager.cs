﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CardManager : ICardService
    {
        ICardDal _cardDal;

        public CardManager(ICardDal cardDal)
        {
            _cardDal = cardDal;
        }
        public IResult CheckIfCardValid(Card card)
        {
            var creditCard = _cardDal.GetAll(c => c.CardNumber == card.CardNumber).FirstOrDefault();

            if (card.CardNumber == creditCard.CardNumber &&
                card.CustomerName == creditCard.CustomerName &&
                card.ExpirationDate == creditCard.ExpirationDate &&
                card.CVV == creditCard.CVV)
            {
                return new SuccessResult(Messages.CardValid);
            }

            return new ErrorResult(Messages.CardInvalid);
        }
    }
}
