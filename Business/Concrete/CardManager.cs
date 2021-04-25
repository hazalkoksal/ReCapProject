using Business.Abstract;
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
            var bankCard = _cardDal.Get(c => c.CardNumber == card.CardNumber) != null ? _cardDal.Get(c => c.CardNumber == card.CardNumber) : null;

            if(bankCard != null)
            {
                if (card.CardNumber == bankCard.CardNumber &&
                    card.CardholderName == bankCard.CardholderName &&
                    card.ExpirationDate == bankCard.ExpirationDate &&
                    card.CVV == bankCard.CVV)
                {
                    return new SuccessResult(Messages.CardValid);
                }

                return new ErrorResult(Messages.CardInvalid);
            }

            return new ErrorResult(Messages.CardInvalid);
        }
    }
}
