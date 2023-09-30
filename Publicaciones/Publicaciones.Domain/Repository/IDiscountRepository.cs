using Publicaciones.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Domain.Repository
{
    public interface IDiscountRepository
    {
        void Save(Discount discount);
        void Update(Discount discount);
        void Remove(Discount discount);
        List<Discount> GetDiscounts();
        //Discount GetDiscountByID(int ID);

    }
}