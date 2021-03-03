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
            //brandManager.Add(new Brand { Name = "Toyota" });
            var brandAddResult = brandManager.Add(new Brand { Name = "a" });

            Console.WriteLine(brandAddResult.Message);

            var brandResult = brandManager.GetAll();

            if (brandResult.Success == true)
            {
                foreach (var brand in brandResult.Data)
                {
                    Console.WriteLine(brand.Id + ": " + brand.Name);
                }
            }

            Console.WriteLine("---");

            ColorManager colorManager = new ColorManager(new EfColorDal());
            //colorManager.Add(new Color { Name = "Beyaz" });
            //colorManager.Add(new Color { Name = "Kırmızı" });
            //colorManager.Add(new Color { Name = "Mavi" });
            //colorManager.Add(new Color { Name = "Gri" });

            var colorResult = colorManager.GetAll();

            if (colorResult.Success == true)
            {
                foreach (var color in colorResult.Data)
                {
                    Console.WriteLine(color.Id + ": " + color.Name);
                }
            }

            Console.WriteLine("---");

            CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(new Car { BrandId = 1, ColorId = 3, ModelYear = 2021, DailyPrice = 350, Description = "Hatchback" });
            //carManager.Add(new Car { BrandId = 2, ColorId = 2, ModelYear = 2020, DailyPrice = 400, Description = "Sedan" });
            //carManager.Add(new Car { BrandId = 3, ColorId = 1, ModelYear = 2021, DailyPrice = 325, Description = "SUV" });
            var carAddResult = carManager.Add(new Car { BrandId = 1, ColorId = 3, ModelYear = 2020, DailyPrice = 0, Description = "Hatchback" });
            //carManager.Add(new Car { BrandId = 4, ColorId = 4, ModelYear = 2021, DailyPrice = 370, Description = "Sedan" });

            Console.WriteLine(carAddResult.Message);

            var carResult = carManager.GetAll();

            if (carResult.Success == true)
            {
                foreach (var car in carResult.Data)
                {
                    Console.WriteLine(car.Id + " - " + car.BrandId + " - " + car.ColorId + " - " + car.ModelYear + " - " + car.DailyPrice + " - " + car.Description);
                }
            }

            //Console.WriteLine("by brand");
            //foreach (var car in carManager.GetAllByBrandId(1))
            //{
            //    Console.WriteLine(car.Id + " - " + car.BrandId + " - " + car.ColorId + " - " + car.ModelYear + " - " + car.DailyPrice + " - " + car.Description);
            //}
            
            Console.WriteLine("---");

            var carDetailResult = carManager.GetCarDetails();

            if (carDetailResult.Success == true)
            {
                foreach (var car in carDetailResult.Data)
                {
                    Console.WriteLine(car.CarId + " - " + car.BrandName + " - " + car.ColorName + " - " + car.DailyPrice);
                }
            }  
        }
    }
}
