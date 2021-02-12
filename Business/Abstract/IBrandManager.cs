using Entities.Concrete;
using Global.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandManager
    {
        IDataResult<List<Brand>> GetAll();
        IDataResult<Brand> GetById(int brandId);
        IResult Add(Brand brand);
        IResult Delete(Brand brand);
        IResult Update(Brand brand);
    }
}
