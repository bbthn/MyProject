using Business.Abstract;
using Business.Contants;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productdal)
        {

            _productDal = productdal;

        }

        public IResult Add(Product Tentity)
        {   

            if(Tentity.ProductName.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productDal.Add(Tentity);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Product Tentity)
        {
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<Product> Get(Expression<Func<Product, bool>> filter)
        {
            return new SuccessDataResult<Product>(_productDal.Get(filter), Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            if (DateTime.Now.Hour==5)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);

            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(filter), Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetByCategoryId(int id)
        {
            return new DataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id), true, "Urunler listendi");
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new DataResult<Product>(_productDal.Get(p => p.ProductId == productId),true,"Urun bulundu!");
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            //return _productDal.GetAll(p => p.UnitPrice <= max && p.UnitPrice >=min);
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice <= max && p.UnitPrice >= min), Messages.ProductFounded);

        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails(),Messages.ProductFounded);
        }

        public IResult Update(Product Tentity)
        {
            return new SuccessDataResult<Product>(Messages.Success);
        }

    
    }
}
