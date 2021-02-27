using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category> // Böyle tanımlayarak aşağıdaki kodları kullanmaya gerek kalmıyor.
                                                               
    {
        //    List<Category> GetAll(); // iki interface'de aynı elemanları kullanacağı için ortak bir interface oluşturalım.
        //    void Add(Category category);
        //    void Update(Category category);
        //    void Delete(Category category);
        //    List<Category> GetAllByCategory(int categoryId); // Bu ürünleri category'e göre listele
    }
}
