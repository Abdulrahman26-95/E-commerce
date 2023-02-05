using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IBasketRepository
    {
        // We Make Specific Repository For Basket Becuase Generic Repository For Entity Framework
        // and Here We Use Redis.
        // We Gonna interact directily with Redis DataBase
        // We Have thre methods To Get a Basket,Update,Create,Delete.
        Task<CustomerBasket> GetBasketAsync(string basketId);
        Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);
        Task<bool> DeleteBasketAsync(string basketId);

    }
}