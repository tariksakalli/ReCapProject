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
            BrandTest();
            Console.WriteLine("---");
            ColorTest();
            Console.WriteLine("---");
            CarTest();
            Console.WriteLine("---");
            UserTest();
            Console.WriteLine("---");
            CustomerTest();
            Console.WriteLine("---");

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var rentStatus1 = rentalManager.Add(new Rental { CarId = 1, CustomerId = 1, RentDate = new DateTime(2021, 03, 10), ReturnDate = new DateTime(2021, 03, 12) });
            Console.WriteLine(rentStatus1.Message);

            var rentStatus2 = rentalManager.Add(new Rental { CarId = 2, CustomerId = 3, RentDate = new DateTime(2021, 03, 11), ReturnDate = null });
            Console.WriteLine(rentStatus2.Message);

            var rentalResult = rentalManager.GetAll();

            if (rentalResult.Success)
            {
                foreach (var rent in rentalResult.Data)
                {
                    Console.WriteLine($"{rent.Id} - {rent.CarId} - {rent.CustomerId} - {rent.RentDate} - {rent.ReturnDate}");
                }
            }
        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            //customerManager.Add(new Customer { UserId = 1, CompanyName = "AK A.Ş." });
            //customerManager.Add(new Customer { UserId = 2, CompanyName = "VT LTD." });

            var customerResult = customerManager.GetAll();

            if (customerResult.Success)
            {
                foreach (var customer in customerResult.Data)
                {
                    Console.WriteLine($"{customer.Id} - {customer.UserId} - {customer.CompanyName}");
                }
            }

            var customerDetailResult = customerManager.GetCustomerDetails();
            if (customerDetailResult.Success)
            {
                foreach (var customer in customerDetailResult.Data)
                {
                    Console.WriteLine($"{customer.CustomerId} - {customer.UserName} - {customer.CompanyName}");
                }
            }
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            //userManager.Add(new User { FirstName = "Ali", LastName = "Kaya", Email = "ali@mail.com", Password = "123" });
            //userManager.Add(new User { FirstName = "Veli", LastName = "Taş", Email = "veli@mail.com", Password = "123" });
            //userManager.Add(new User { FirstName = "Hasan", LastName = "Demir", Email = "hasan@mail.com", Password = "123" });
            //userManager.Add(new User { FirstName = "Hakkı", LastName = "Çelik", Email = "hakkı@mail.com", Password = "123" });

            var userResult = userManager.GetAll();

            if (userResult.Success)
            {
                foreach (var user in userResult.Data)
                {
                    Console.WriteLine($"{user.Id} - {user.FirstName} {user.LastName} - {user.Email}");
                }
            }

            var selectedUser = userManager.GetUserById(2);

            if (selectedUser.Success)
            {
                Console.WriteLine($"Seçilen kullanıcı: {selectedUser.Data.FirstName} {selectedUser.Data.LastName}");
            }
        }

        private static void ColorTest()
        {
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
        }

        private static void BrandTest()
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
        }

        private static void CarTest()
        {
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
