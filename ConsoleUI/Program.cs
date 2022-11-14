using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductTest();



            CategoryTest();

        }

        private static void CategoryTest()
        {
            CategoryManager categorymanager = new CategoryManager(new EfCategoryDal());

            foreach (var category in categorymanager.GetAll())
            {
                Console.WriteLine(category.CategoryName);

            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());


            foreach (var product in productManager.GetProductDetails().Data)
            {
                
                Console.WriteLine(product.ProductName+"  "+product.CategoryName);

            }
        }
    }
}
