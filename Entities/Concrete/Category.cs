using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Category : IEntity // using Core.Entities klasörüne bağlı olacaklar. Çünkü Abstract'ın içinde yer alan IEntity.cs artık genel olarak kullanılacağı Core katmanında Entities klasörü altında.
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
