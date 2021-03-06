﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Global.Aspects.Autofac;
using Global.Aspects.Autofac.Validation;
using Global.Utilities.Business;
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
            IResult result = BusinessRules.Run(
                CarCheckForRent(rental.CarId,rental.RentDate,rental.ReturnDate)
                );

            if (result != null)
            {
                return result;
            }

            _rentalDal.Add(rental);
            return new SuccessDataResult<Rental>(rental,Messages.CarRented);
        }

        public IResult Delete(Rental rental)
        {
            IResult result = BusinessRules.Run(
                RentalExists(rental.Id)
                );

            if (result != null)
            {
                return result;
            }

            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            IResult result = BusinessRules.Run(
                RentalExists(rentalId)
                );

            if (result != null)
            {
                return new ErrorDataResult<Rental>(result.Message);
            }
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == rentalId), Messages.RentalListed);
        }

        public IResult ReturnCar(Rental rental)
        {
            IResult result = BusinessRules.Run(
                CarCheckForReturn(rental.Id)
                );

            if (result != null)
            {
                return result;
            }

            _rentalDal.Update(rental);
            return new SuccessResult(Messages.CarReturned);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.RentalListed);
        }

        private IDataResult<Rental> CarCheckForRent(int carId,DateTime startDate,DateTime endDate)
        {
            var existRental = _rentalDal.Get(r => r.CarId == carId && r.ReturnDate >= startDate);
            if (existRental != null)
            {
                return new ErrorDataResult<Rental>(Messages.CarNotRent);
            }
            return new SuccessDataResult<Rental>();
        }

        private IResult CarCheckForReturn(int carId)
        {
            var existRent = _rentalDal.Get(r => r.Id == carId && r.ReturnDate == null);
            if (existRent == null)
            {
                return new ErrorResult(Messages.RentalNotFound);

            }
            return new SuccessResult();
        }

        private IResult RentalExists(int id)
        {
            if (_rentalDal.Exists(b => b.Id == id))
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.RentalNotFound);
        }
    }
}
