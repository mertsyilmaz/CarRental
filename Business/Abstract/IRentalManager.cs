using Entities.Concrete;
using Global.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalManager
    {
        IResult RentCar(Rental rental);
        IResult Delete(Rental rental);
        IResult ReturnCar(Rental rental);
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(int rentalId);

    }
}
