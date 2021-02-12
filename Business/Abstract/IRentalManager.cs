using Entities.Concrete;
using Global.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalManager
    {
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(int rentalId);
        IDataResult<List<Rental>> GetRentalsByRentDate(DateTime rentDate);
        IDataResult<List<Rental>> GetRentalsBetweenDate(DateTime rentDate, DateTime returnDate);

    }
}
