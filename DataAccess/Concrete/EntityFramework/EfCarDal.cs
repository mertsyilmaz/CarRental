using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Global.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from cr in context.Cars
                             join cl in context.Colors
                             on cr.ColorId equals cl.Id
                             join br in context.Brands
                             on cr.BrandId equals br.Id
                             select new CarDetailDto
                             {
                                 CarId = cr.Id,
                                 BrandName = br.Name,
                                 CarName = cr.Name,
                                 ColorName = cl.Name,
                                 DailyPrice = cr.DailyPrice,
                                 Description = cr.Description,
                                 ModelYear = cr.ModelYear
                             };
                return result.ToList();
            }
        }
    }
}
