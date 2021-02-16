using Business.Abstract;
using Business.Constants;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Global.Utilities.Results;
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

        public IResult Add(Car car)
        {
            if (_carDal.Get(b => b.Name == car.Name) != null)
            {
                return new ErrorResult(Messages.CarAlreadyExists);
            }

            if (car.DailyPrice > 0 && car.Name.Length >=2)
            {
                _carDal.Add(car);
                return new SuccessResult();
            }

            return new ErrorResult();
        }

        public IResult Delete(Car car)
        {
            if (!Exists(car.Id))
            {
                return new ErrorResult(Messages.CarNotFound);
            }

            _carDal.Delete(car);
            return new SuccessResult();
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<Car> GetById(int CarId)
        {
            if (!Exists(CarId))
            {
                return new ErrorDataResult<Car>(Messages.CarNotFound);
            }

            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == CarId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }

        public IResult Update(Car car)
        {
            if (!Exists(car.Id))
            {
                return new ErrorDataResult<Car>(Messages.CarNotFound);
            }
            _carDal.Update(car);
            return new SuccessResult();
        }

        private bool Exists(int id)
        {
            return _carDal.Exists(c => c.Id == id);
        }
    }
}
