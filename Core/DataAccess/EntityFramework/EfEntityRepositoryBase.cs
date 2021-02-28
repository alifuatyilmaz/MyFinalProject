using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    // Bu kod kısmı önceden EfProductDal içinde kullanılıyordu ve TEntity'lerin yerine Product , TContext yerine NorthwindContext tanımlıydı. 
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity: class, IEntity , new()
        where TContext :DbContext, new()
    {
        public void Add(TEntity entity) // Burada TEntity aslında hem Product hem Customer hem Category'i temsil edecek.
        {
            using (TContext context = new TContext()) // Burada NorthwindContext yerine TContext tanımlanacak.
            {
                var addedEntity = context.Entry(entity); // Veri kaynağından gönderdiğim Product'tan bir tane nesneyi eşleştir.Ama bir ekleme olacağı için eşleştirme olmayacak direkt ekleyecek.
                addedEntity.State = EntityState.Added; // Nesnenin eklenecek bir nesne olduğunu gösteriyoruz.
                context.SaveChanges(); // Şimdi ekle.
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity); // Veri kaynağından gönderdiğim Product'tan bir tane nesneyi eşleştir.
                deletedEntity.State = EntityState.Deleted; // Nesnenin silinecek bir nesne olduğunu gösteriyoruz.
                context.SaveChanges(); // Şimdi sil.
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter) // Tek data getirecek. 
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null) // Eğer filtre verilmemişse tablodaki tüm kayıtları getirir. Eğer filtre verilmişse onu uygula.
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList(); // Eğer filter null ise tüm kayıtlar, filtre yoksa : sonraki kısmı çalıştırır(Select * from Products sorgusunu çalıştırıyor ve listeye çeviriyor.).
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity); // Veri kaynağından gönderdiğim Product'tan bir tane nesneyi eşleştir.
                updatedEntity.State = EntityState.Modified; // Nesnenin günecllenecek bir nesne olduğunu gösteriyoruz.
                context.SaveChanges(); // Şimdi güncelle.
            }
        }
    }
}
