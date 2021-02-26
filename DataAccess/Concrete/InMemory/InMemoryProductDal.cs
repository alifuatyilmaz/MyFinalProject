﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal() //Constructor
        {
            _products = new List<Product> { // Bellekte ürünlerimizi oluşturduk.
                new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
                new Product{ProductId=2,CategoryId=1,ProductName="Kamera",UnitPrice=500,UnitsInStock=3},
                new Product{ProductId=3,CategoryId=2,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2},
                new Product{ProductId=4,CategoryId=2,ProductName="Klavye",UnitPrice=150,UnitsInStock=65},
                new Product{ProductId=5,CategoryId=2,ProductName="Fare",UnitPrice=85,UnitsInStock=1}
            };    
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ - Language Integrated Query ile aşağıdaki kodu yazacağız.
            //Product productToDelete = null;
            //foreach (var p in _products) // Listeyi tek tek dolaşmak için .Ama bunu kullanmayacağız. Elemanları tek tek dolaşmak gerekir.
            //{
            //    if(product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}
            //Yukarıdaki kodun LINQ karşılığı aşağıdaki tek satırlık koddur.

            Product productToDelete =  _products.SingleOrDefault(p=>p.ProductId == product.ProductId); // SingleOrDefault aslında foreach'in yerine geçiyor.p takma bir isim listedeki elemanları temsil ediyor. Benim gönderdiğim product.ProductId' sine eşit mi diye kontrol ediyor.
            // Yukarıdaki satır ürünü bulur.
            _products.Remove(productToDelete); //  SingleOrDefault tek bir değer arar.
        }
        
        public List<Product> GetAll() // Veritabanındaki datayı Business katmanına göndermek için
        {
            return _products;
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün id'sine sahip olan listedeki ürünü bul.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList(); // İçindeki şarta uyan bütün elemanları yeni bir liste haline getirir.
        }
    }
}
