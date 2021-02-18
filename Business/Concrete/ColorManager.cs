using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using Entities.Concrete;
using Global.Aspects.Autofac;
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

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            if (_colorDal.Get(c => c.Name == color.Name)!= null)
            {
                return new ErrorResult(Messages.ColorAlreadyExists);
            }

            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Color color)
        {
            if (!Exists(color.Id))
            {
                return new ErrorResult(Messages.ColorNotFound);
            }
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),Messages.ColorListed);
        }

        public IDataResult<Color> GetById(int colorId)
        {
            if (!Exists(colorId))
            {
                return new ErrorDataResult<Color>(Messages.ColorNotFound);
            }
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id == colorId), Messages.ColorListed);
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color)
        {
            if (!Exists(color.Id))
            {
                return new ErrorResult(Messages.ColorNotFound);
            }
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }

        private bool Exists(int id)
        {
            return _colorDal.Exists(c => c.Id == id);
        }
    }
}
