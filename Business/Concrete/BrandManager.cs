using Business.Abstract;
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
    public class BrandManager : IBrandManager
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            IResult result = BusinessRules.Run(
                BrandNameCheck(brand.Name)
                );

            if (result != null)
            {
                return result;
            }

            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Delete(Brand brand)
        {
            IResult result = BusinessRules.Run(
                BrandExists(brand.Id)
                );

            if (result != null)
            {
                return result;
            }

            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.BrandListed);
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            IResult result = BusinessRules.Run(
                BrandExists(brandId)
                );

            if (result != null)
            {
                return new ErrorDataResult<Brand>(result.Message);
            }
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.Id == brandId),Messages.BrandListed);
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {
            IResult result = BusinessRules.Run(
                BrandExists(brand.Id)
                );

            if (result != null)
            {
                return result;
            }

            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }

        private IResult BrandNameCheck(string brandName)
        {
            if (_brandDal.Get(b => b.Name == brandName) != null)
            {
                return new ErrorResult(Messages.BrandAlreadyExists);
            }
            return new SuccessResult();
        }

        private IResult BrandExists(int id)
        {
            if (_brandDal.Exists(b => b.Id == id))
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.BrandNotFound);
        }
    }
}
