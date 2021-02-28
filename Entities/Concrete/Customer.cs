using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Customer : IEntity // using Core.Entities klasörüne bağlı olacaklar. Çünkü Abstract'ın içinde yer alan IEntity.cs artık genel olarak kullanılacağı Core katmanında Entities klasörü altında.
    {
        public string CustomerId { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
    }
}
