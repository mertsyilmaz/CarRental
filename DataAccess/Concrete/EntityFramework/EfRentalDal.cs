using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Global.DataAccess.EntityFramework;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from rn in context.Rentals
                             join cr in context.Cars
                             on rn.CarId equals cr.Id
                             join cu in context.Customers
                             on rn.CustomerId equals cu.Id
                             select new RentalDetailDto
                             {
                                 CarName = cr.Name,
                                 CompanyName = cu.CompanyName,
                                 RentalId = rn.Id,
                                 RentDate = rn.RentDate
                             };
                return result.ToList();
            }
        }
    }
}
