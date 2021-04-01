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
                             join br in context.Brands
                             on cr.BrandId equals br.Id
                             join cu in context.Customers
                             on rn.CustomerId equals cu.Id
                             join usr in context.Users
                             on cu.UserId equals usr.Id
                             select new RentalDetailDto
                             {
                                 CarName = cr.Name,
                                 CompanyName = cu.CompanyName,
                                 RentalId = rn.Id,
                                 RentDate = rn.RentDate,
                                 UserFirstName = usr.Firstname,
                                 UserLastName = usr.Lastname,
                                 BrandName = br.Name
                             };
                return result.ToList();
            }
        }
    }
}
