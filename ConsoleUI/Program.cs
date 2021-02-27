using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;


namespace ConsoleUI
{
    class Program
    {
        //ClassLibrary : Birbiriyle ilişkili classları koyduğumuz kütüphaneye denir.(Business, DataAccess ve Entities ClassLibrary olarak)
        //Abstract klasörlerine soyut nesneleri koyacağız.Bunlar bizim referans tutucularımız olacak.Yani interface'leri, abstract nesneleri ve base classları bu klasörlerin içine koyacağız.
        //Concrete klasörlerine somut nesneleri yani gerçek işi yapan classları koyacağız.

        //Burada tüm katmanları kullanacağımız için hepsinden referans alacağız.ConsoleUI sağ tık->Project Reference'dan hepsini seç.
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal()); // Burada InMemoryProductDal yerine EfProductDal kullan(Sisteminin değiştiğini düşün).

            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}
