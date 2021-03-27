using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using Global.Aspects.Autofac;
using Global.Aspects.Autofac.Caching;
using Global.Aspects.Autofac.Performance;
using Global.Aspects.Autofac.Transaction;
using Global.Aspects.Autofac.Validation;
using Global.CrossCuttingConcerns.Validation.FluentValidation;
using Global.Utilities.Business;
using Global.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarManager
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarManager.Get")]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(
                CarNameCheck(car.Name)
                );

            if (result != null)
            {
                return result;
            }

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            IResult result = BusinessRules.Run(
                CarExists(car.Id)
                );

            if (result != null)
            {
                return result;
            }

            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<Car> GetById(int CarId)
        {
            IResult result = BusinessRules.Run(
                CarExists(CarId)
                );

            if (result != null)
            {
                return new ErrorDataResult<Car>(result.Message);
            }

            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == CarId), Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId), Messages.CarListed);
        }

        public IDataResult<List<CarsWithPhotosDto>> GetCarsWithPhotos()
        {
            return new SuccessDataResult<List<CarsWithPhotosDto>>(_carDal.GetCarsWithPhotos(), Messages.CarListed);
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarManager.Get")]
        public IResult Update(Car car)
        {
            IResult result = BusinessRules.Run(
                CarExists(car.Id)
                );

            if (result != null)
            {
                return result;
            }

            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        private IResult CarNameCheck(string carName)
        {
            if (_carDal.Get(b => b.Name == carName) != null)
            {
                return new ErrorResult(Messages.CarAlreadyExists);
            }
            return new SuccessResult();
        }

        private IResult CarExists(int id)
        {
            if (_carDal.Exists(b => b.Id == id))
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CarNotFound);
        }

        [TransactionScopeAspect]
        public IResult AddTransactionTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 2)
            {
                throw new Exception("Error");
            }
            Add(car);
            return null;
        }
    }
}
