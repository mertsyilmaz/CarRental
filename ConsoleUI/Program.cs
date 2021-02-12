using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddColor("Blue");
            //RentCar();
            ReturnCar();

            Console.WriteLine("-------------------------------");
            GetCarsDetails();
            Console.WriteLine("-------------------------------");
            GetBrands();
            Console.WriteLine("-------------------------------");
            GetColors();
            Console.WriteLine("-------------------------------");
            GetRentals();
            Console.WriteLine("-------------------------------");
            
        }

        private static void ReturnCar()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.ReturnCar(new Rental
            {
                Id=4,
                CarId = 1,
                CustomerId = 1,
                ReturnDate = DateTime.Now
            });
            Console.WriteLine(result.Message);
        }

        private static void RentCar()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.RentCar(new Rental
            {
                CarId = 1,
                CustomerId = 1,
                RentDate = DateTime.Now,
                ReturnDate = null
            });
            Console.WriteLine(result.Message);
        }

        private static void GetRentals()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine("{0} - {1} - {2} - {3} - {4}", rental.Id, rental.CarId, rental.CustomerId, rental.RentDate, rental.ReturnDate);
            }
        }

        private static void AddColor(string colorName)
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { Name = colorName });
        }

        private static void GetColors()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine("{0} - {1} ", color.Id, color.Name);
            }
        }

        private static void GetBrands()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine("{0} - {1} ", brand.Id, brand.Name);
            }
        }

        private static void GetCarsDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("{0} - {1} - {2} - {3}", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
            }
        }
    }
}
