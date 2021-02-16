using Business.Abstract;
using Business.Constants;
using DataAccess.Abstract;
using Entities.Concrete;
using Global.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorManager
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            if (_colorDal.Get(c => c.Name == color.Name)!= null)
            {
                return new ErrorResult(Messages.ColorAlreadyExists);
            }
            _colorDal.Add(color);
            return new SuccessResult();
        }

        public IResult Delete(Color color)
        {
            if (!Exists(color.Id))
            {
                return new ErrorResult(Messages.ColorNotFound);
            }
            _colorDal.Delete(color);
            return new SuccessResult();
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<Color> GetById(int colorId)
        {
            if (!Exists(colorId))
            {
                return new ErrorDataResult<Color>(Messages.ColorNotFound);
            }
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id == colorId));
        }

        public IResult Update(Color color)
        {
            if (!Exists(color.Id))
            {
                return new ErrorResult(Messages.ColorNotFound);
            }
            _colorDal.Update(color);
            return new SuccessResult();
        }

        private bool Exists(int id)
        {
            return _colorDal.Exists(c => c.Id == id);
        }
    }
}
