﻿using Business.Abstract;
using Business.Constants;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public IResult Add(Brand brand)
        {
            if (_brandDal.Get(b => b.Name == brand.Name) != null)
            {
                return new ErrorResult(Messages.BrandAlreadyExists);
            }
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Delete(Brand brand)
        {
            if (!Exists(brand.Id))
            {
                return new ErrorResult(Messages.BrandNotFound);
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
            if (!Exists(brandId))
            {
                return new ErrorDataResult<Brand>(Messages.BrandNotFound);
            }
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.Id == brandId),Messages.BrandListed);
        }

        public IResult Update(Brand brand)
        {
            if (!Exists(brand.Id))
            {
                return new ErrorDataResult<Brand>(Messages.BrandNotFound);
            }
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }

        private bool Exists(int id)
        {
            return _brandDal.Exists(b => b.Id == id);
        }
    }
}
