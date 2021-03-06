﻿using Entities.Concrete;
using Entities.DTOs;
using Global.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarManager
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int CarId);
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        IDataResult<List<Car>> GetCarsByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<CarDetailDto> GetCarDetailById(int carId);
        IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetCarDetailsByFilter(int? colorId,int? brandId);
        IDataResult<List<CarsWithPhotosDto>> GetCarsWithPhotos();
        IResult Add(Car car);
        IResult AddTransactionTest(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
    }
}
