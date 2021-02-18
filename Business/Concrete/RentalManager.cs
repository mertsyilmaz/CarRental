using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Global.Aspects.Autofac;
using Global.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalManager
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult RentCar(Rental rental)
        {
            var existRental = _rentalDal.Get(r => r.CarId == rental.CarId && r.ReturnDate == null);
            if (existRental != null)
            {
                return new ErrorResult(Messages.CarNotRent);
            }

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.CarRented);
        }

        public IResult Delete(Rental rental)
        {
            if (!Exists(rental.Id))
            {
                return new ErrorResult(Messages.RentalNotFound);
            }

            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.RentalListed);
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            if (!Exists(rentalId))
            {
                return new ErrorDataResult<Rental>(Messages.RentalNotFound);
            }
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == rentalId),Messages.RentalListed);
        }

        public IResult ReturnCar(Rental rental)
        {
            var existRent = _rentalDal.Get(r => r.Id == rental.Id && r.ReturnDate == null);
            if (existRent != null)
            {
                _rentalDal.Update(rental);
                return new SuccessResult(Messages.CarReturned);
            }
            else
            {
                return new ErrorResult(Messages.RentalNotFound);
            }
            
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(),Messages.RentalListed);
        }

        private bool Exists(int id)
        {
            return _rentalDal.Exists(r => r.Id == id);
        }
    }
}
