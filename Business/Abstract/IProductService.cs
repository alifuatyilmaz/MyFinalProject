﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll(); // Business katmanı her iki katmandan da referans almalı.Her iki katmanın bilgilerini kullanıyor.
    }
}
