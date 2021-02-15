using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        public IResult RentCar(Rental rental)
        {
            var existRental = _rentalDal.Get(r => r.CarId == rental.CarId && r.ReturnDate == null);
            if (existRental != null)
            {
                return new ErrorResult("Bu araç kiralanamaz.");
            }

            _rentalDal.Add(rental);
            return new SuccessResult("Kiralama işlemi başarılı.");
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == rentalId));
        }

        public IResult ReturnCar(Rental rental)
        {
            var existRent = _rentalDal.Get(r => r.Id == rental.Id && r.ReturnDate == null);
            if (existRent != null)
            {
                _rentalDal.Update(rental);
                return new SuccessResult("Araç teslim edildi.");
            }
            else
            {
                return new ErrorResult("Araç teslim etme işlemi yapılamaz.");
            }
            
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }
    }
}
