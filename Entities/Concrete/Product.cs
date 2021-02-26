using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Product : IEntity // Public olarak tanımlanmalı. Bu classa diğer katmanlarında ulaşabilmesi için(Business ve DataAccess classları). Bir classın defaultu internal'dır.Yani sadece Entities class'ı ulaşabilir.
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; } // short, int'in bir düşüğü
        public int UnitPrice { get; set; }
    }
}
