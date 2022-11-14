using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product> //product table ile lakalaı operasonları yapacak interface
    {
        List<ProductDetailDto> GetProductDetails();



    

    }
}
