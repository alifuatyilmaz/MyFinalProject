using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>// Bu Product ile ilgili yapacağımız operasyonları içeren bir interface. SQL komutları select ,update, delete ,insert vb.
                                                           // Böyle tanımlayarak aşağıdaki kodları kullanmaya gerek kalmıyor.
                                                          
    {
        //List<Product> GetAll(); // Başka katmandan veri kullanmak için referans verilmeli.DataAccess'e sağ tık Add->Project References ile Entities katmanından referans alıyoruz.
        //void Add(Product product);
        //void Update(Product product);
        //void Delete(Product product);
        //List<Product> GetAllByCategory(int categoryId); // Bu ürünleri category'e göre listele
        //Burada ortak bir interface oluşturacağımız için sildik.
    }
}
