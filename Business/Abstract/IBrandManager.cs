using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandManager
    {
        List<Brand> GetAll();
        Brand GetById(int brandId);
        void Add(Brand brand);
    }
}
