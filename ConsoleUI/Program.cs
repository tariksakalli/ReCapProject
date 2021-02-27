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
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //brandManager.Add(new Brand { Name = "Volvo" });
            //brandManager.Add(new Brand { Name = "BMW" });
            //brandManager.Add(new Brand { Name = "Mazda" });

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Id + ": " + brand.Name);
            }

            Console.WriteLine("---");

            ColorManager colorManager = new ColorManager(new EfColorDal());
            //colorManager.Add(new Color { Name = "Beyaz" });
            //colorManager.Add(new Color { Name = "Kırmızı" });
            //colorManager.Add(new Color { Name = "Mavi" });

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Id + ": " + color.Name);
            }

            Console.WriteLine("---");

            CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(new Car { BrandId = 1, ColorId = 3, ModelYear = 2021, DailyPrice = 350, Description = "Hatchback" });
            //carManager.Add(new Car { BrandId = 2, ColorId = 2, ModelYear = 2020, DailyPrice = 400, Description = "Sedan" });
            //carManager.Add(new Car { BrandId = 3, ColorId = 1, ModelYear = 2021, DailyPrice = 325, Description = "SUV" });
            carManager.Add(new Car { BrandId = 1, ColorId = 3, ModelYear = 2020, DailyPrice = 0, Description = "Hatchback" });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Id + " - " + car.BrandId + " - " + car.ColorId + " - " + car.ModelYear + " - " + car.DailyPrice + " - " + car.Description);
            }

            Console.WriteLine("---");

            Console.WriteLine("by brand");
            foreach (var car in carManager.GetAllByBrandId(1))
            {
                Console.WriteLine(car.Id + " - " + car.BrandId + " - " + car.ColorId + " - " + car.ModelYear + " - " + car.DailyPrice + " - " + car.Description);
            }

        }
    }
}
