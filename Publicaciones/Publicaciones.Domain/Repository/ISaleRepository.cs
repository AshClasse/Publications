using Publicaciones.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Publicaciones.Domain.Repository
{
    public interface ISaleRepository
    {
        void Save(Sale sale);
        void Update(Sale sale);
        void Remove(Sale sale);
        List<Sale> GetSales();
        Sale GetSaleByID(string storID, string ordNum, string titleID);

    }
}