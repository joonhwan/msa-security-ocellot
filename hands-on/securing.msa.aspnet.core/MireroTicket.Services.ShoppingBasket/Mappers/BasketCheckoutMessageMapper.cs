using System;
using System.Collections.Generic;
using MireroTicket.Services.ShoppingBasket.Messages;
using MireroTicket.Services.ShoppingBasket.Models;

namespace MireroTicket.Services.ShoppingBasket.Mappers
{
    public static class BasketCheckoutMessageMapper
    {
        public static BasketCheckoutMessage From(BasketCheckout model, string userId)
        {
            return new BasketCheckoutMessage
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTimeOffset.Now,
                // from model 
                Address = model.Address,
                City = model.City,
                Country = model.Country,
                Email = model.Email,
                BasketId = model.BasketId,
                CardExpiration = model.CardExpiration,
                CardName = model.CardName,
                CardNumber = model.CardNumber,
                CvvCode = model.CvvCode,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserId = userId,
                ZipCode = model.ZipCode,
                // model 에 없는거...
                BasketLines = new List<BasketLineMessage>(), 
                BasketTotal = 0,

            };
        }
    }
}