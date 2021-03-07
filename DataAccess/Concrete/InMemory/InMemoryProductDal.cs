using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;  // Global değişken
        public InMemoryProductDal()
        {
            _products = new List<Product> { 
            new Product{CategoryId=1, ProductId=1, ProductName="Bardak", UnitPrice=15, UnitsInStock=15},
            new Product{CategoryId=2, ProductId=1, ProductName="Kamera", UnitPrice=500, UnitsInStock=3},
            new Product{CategoryId=3, ProductId=2, ProductName="Telefon", UnitPrice=1500, UnitsInStock=2},
            new Product{CategoryId=4, ProductId=2, ProductName="Klavye", UnitPrice=150, UnitsInStock=65},
            new Product{CategoryId=5, ProductId=2, ProductName="Fare", UnitPrice=85, UnitsInStock=1}
         
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            // LINQ - Language Integrated Query - Dile Gömülü Sorgulama
            // Aşağıdaki kodun LINQ ile daha basit kullanımı
            // tek bir değer için    // p takma ad
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete);


            //Product productToDelete = null;
            //foreach (var p in _products)
            //{
            //    if (product.ProductID == p.ProductID)
            //    {
            //        productToDelete = p;
            //    }
            //}
            //_products.Remove(productToDelete);
        }

        public void Update(Product product)
        {
            // GÖnderdiğim ürün idsine sahip olan listedeki ürünü bul
            Product productToUpdate =_products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.ProductId = product.ProductId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }


        public List<Product> GetAll()
        {
            return _products;
        }


        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList(); // içerdeki şarta uyan bütün elamanları yeni bir liste haline getirip onu döndürür
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
