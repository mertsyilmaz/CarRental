using Business.Abstract;
using Business.BussinesAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using Entities.Concrete;
using Global.Aspects.Autofac;
using Global.Utilities.Business;
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

        [SecuredOperation("admin,color.add")]
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            IResult result = BusinessRules.Run(
                ColorNameCheck(color.Name)
                ) ;

            if (result != null)
            {
                return result;
            }

            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Color color)
        {
            IResult result = BusinessRules.Run(
                ColorExists(color.Id)
                );

            if (result != null)
            {
                return result;
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
            IResult result = BusinessRules.Run(
                ColorExists(colorId)
                );

            if (result != null)
            {
                return new ErrorDataResult<Color>(result.Message);
            }

            return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id == colorId), Messages.ColorListed);
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color)
        {
            IResult result = BusinessRules.Run(
                ColorExists(color.Id)
                );

            if (result != null)
            {
                return result;
            }

            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }

        private IResult ColorNameCheck(string colorName)
        {
            if (_colorDal.Get(b => b.Name == colorName) != null)
            {
                return new ErrorResult(Messages.ColorAlreadyExists);
            }
            return new SuccessResult();
        }

        private IResult ColorExists(int id)
        {
            if (_colorDal.Exists(b => b.Id == id))
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.ColorNotFound);
        }
    }
}
