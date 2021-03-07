using Entities.Concrete; // DataAccess bölümünden dependencies e Entities i referans verdik
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
       
    }
}
