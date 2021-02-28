using Core.DataAccess.EntityFramework;
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
    // Bu kodun sadece Product yazan kısımları değişecek ve Category ve Customer olarak yazılacak. Bu yüzden ortak bir katman oluşturup içine kodlar oluşturulmalıdır(Core katmanı).
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext> ,IProductDal
    {
        // EntityFramework klasörüne sağ tık.Burada projeye NuGet packages ekliyoruz. entityframeworkcore.sql v3.1.11
        // Burdan kestiğimiz kodu Core katmanında EntityFramework klasörü altında EfEntityRepositoryBase içine yapıştır. Çünkü ortak kullanılacak.


    }
}
