using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll(Expression<Func<Product, bool>> filter = null);
        IDataResult<Product> Get(Expression<Func<Product, bool>> filter);
        IDataResult<Product> GetById(int productId);
        IResult Delete(Product Tentity); 
        IResult Add(Product Tentity);
        IResult Update(Product Tentity);
        IDataResult<List<Product>> GetByCategoryId(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min,decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();


    }
}
