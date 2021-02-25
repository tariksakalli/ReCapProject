using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            Console.WriteLine("##GET ALL##");
            GetAllCars(carManager);

            Console.WriteLine("##GET BY ID##");
            var selectedCar = carManager.GetById(2);
            Console.WriteLine("Your car is: " + selectedCar.BrandId + " " + selectedCar.ModelYear);

            Console.WriteLine("##ADD##");
            carManager.Add(new Car { Id = 6, BrandId = 3, ColorId = 2, ModelYear = 2021, DailyPrice = 1500, Description = "Sport" });
            GetAllCars(carManager);

            Console.WriteLine("##UPDATE##");
            carManager.Update(new Car { Id = 6, BrandId = 3, ColorId = 2, ModelYear = 2021, DailyPrice = 750, Description = "Sedan" });
            GetAllCars(carManager);

            Console.WriteLine("##DELETE##");
            carManager.Delete(new Car { Id = 6, BrandId = 3, ColorId = 2, ModelYear = 2021, DailyPrice = 750, Description = "Sedan" });
            GetAllCars(carManager);
        }

        private static void GetAllCars(CarManager carManager)
        {
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + " - " + car.BrandId + " - " + car.ColorId + " - " + car.ModelYear + " - " + car.DailyPrice + " - " + car.Description);
            }
        }
    }
}
