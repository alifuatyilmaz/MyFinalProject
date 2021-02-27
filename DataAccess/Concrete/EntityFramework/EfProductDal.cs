using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    // Bu kodun sadece Product yazan kısımları değişecek ve Category ve Customer olarak yazılacak.
    public class EfProductDal : IProductDal
    {
        // EntityFramework klasörüne sağ tık.Burada projeye NuGet packages ekliyoruz. entityframeworkcore.sql v3.1.11
        public void Add(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var addedEntity = context.Entry(entity); // Veri kaynağından gönderdiğim Product'tan bir tane nesneyi eşleştir.Ama bir ekleme olacağı için eşleştirme olmayacak direkt ekleyecek.
                addedEntity.State = EntityState.Added; // Nesnenin eklenecek bir nesne olduğunu gösteriyoruz.
                context.SaveChanges(); // Şimdi ekle.
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity); // Veri kaynağından gönderdiğim Product'tan bir tane nesneyi eşleştir.
                deletedEntity.State = EntityState.Deleted; // Nesnenin silinecek bir nesne olduğunu gösteriyoruz.
                context.SaveChanges(); // Şimdi sil.
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter) // Tek data getirecek. 
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }
        
        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null) // Eğer filtre verilmemişse tablodaki tüm kayıtları getirir. Eğer filtre verilmişse onu uygula.
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList(); // Eğer filter null ise tüm kayıtlar, filtre yoksa : sonraki kısmı çalıştırır(Select * from Products sorgusunu çalıştırıyor ve listeye çeviriyor.).
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity); // Veri kaynağından gönderdiğim Product'tan bir tane nesneyi eşleştir.
                updatedEntity.State = EntityState.Modified; // Nesnenin günecllenecek bir nesne olduğunu gösteriyoruz.
                context.SaveChanges(); // Şimdi güncelle.
            }
        }
    }
}
