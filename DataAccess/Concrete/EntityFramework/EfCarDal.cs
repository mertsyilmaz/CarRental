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

        public CarDetailDto GetCarDetailById(int carId)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from cr in context.Cars
                             join cl in context.Colors
                             on cr.ColorId equals cl.Id
                             join br in context.Brands
                             on cr.BrandId equals br.Id
                             where cr.Id == carId
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
                return result.SingleOrDefault();
            }
        }

        public List<CarDetailDto> GetCarDetailsByBrandId(int brandId)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from cr in context.Cars
                             join cl in context.Colors
                             on cr.ColorId equals cl.Id
                             join br in context.Brands
                             on cr.BrandId equals br.Id
                             where cr.BrandId == brandId
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

        public List<CarDetailDto> GetCarDetailsByColorId(int colorId)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from cr in context.Cars
                             join cl in context.Colors
                             on cr.ColorId equals cl.Id
                             join br in context.Brands
                             on cr.BrandId equals br.Id
                             where cr.ColorId == colorId
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

        public List<CarsWithPhotosDto> GetCarsWithPhotos()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from cr in context.Cars
                             join cl in context.Colors
                             on cr.ColorId equals cl.Id
                             join br in context.Brands
                             on cr.BrandId equals br.Id
                             select new CarsWithPhotosDto
                             {
                                 CarId = cr.Id,
                                 BrandName = br.Name,
                                 CarName = cr.Name,
                                 ColorName = cl.Name,
                                 DailyPrice = cr.DailyPrice,
                                 Description = cr.Description,
                                 ModelYear = cr.ModelYear,
                                 Photos = context.Photos.Where(p => p.CarId == cr.Id).ToList()
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByFilter(int? colorId, int? brandId)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from cr in context.Cars
                             join cl in context.Colors
                             on cr.ColorId equals cl.Id
                             join br in context.Brands
                             on cr.BrandId equals br.Id
                             where (colorId == null ? true : cr.ColorId == colorId)  && (brandId == null ? true : cr.BrandId == brandId)
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
