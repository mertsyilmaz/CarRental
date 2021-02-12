using Entities.Concrete;
using Global.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorManager
    {
        IDataResult<List<Color>> GetAll();
        IDataResult<Color> GetById(int colorId);
        IResult Add(Color color);
        IResult Delete(Color color);
        IResult Update(Color color);
    }
}
