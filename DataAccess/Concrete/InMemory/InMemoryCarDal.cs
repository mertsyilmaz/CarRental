using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=1,ModelYear=DateTime.Now,DailyPrice=12.50M,Description="Description 1"},
                new Car{Id=2,BrandId=1,ColorId=1,ModelYear=DateTime.Now,DailyPrice=14.70M,Description="Description 2"},
                new Car{Id=3,BrandId=2,ColorId=1,ModelYear=DateTime.Now,DailyPrice=18.50M,Description="Description 3"},
                new Car{Id=4,BrandId=2,ColorId=2,ModelYear=DateTime.Now,DailyPrice=12.50M,Description="Description 4"},
                new Car{Id=5,BrandId=3,ColorId=2,ModelYear=DateTime.Now,DailyPrice=9.50M,Description="Description 5"},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(c => c.Id == id);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
