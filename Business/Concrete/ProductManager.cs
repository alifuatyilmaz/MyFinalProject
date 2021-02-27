using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal; // Ne EntityFramework ne de InMemory ismi geçecek.Soyut nesneyle bağlantı kuracak. 

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll() // DataAccess'te Concrete'te yaptığımız her işlemi burası ile ilişkilendir.
        {
            //İş kodları(İf)
            return _productDal.GetAll();
        }
    }
}
