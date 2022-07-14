using Business.Concrete;
using Data_Access.Concrete.EntityFrameWork;
using Data_Access.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //CarDtoTest();
        }

        private static void CarDtoTest()
        {
            CarManager manager = new CarManager(new EfCarDal());
            Console.WriteLine("Total Cars:" + manager.Len);
            foreach (var item in manager.GetCarDetails())
            {
                Console.WriteLine(item.CarName + "/" + item.ColorName + "/" + item.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager manager = new CarManager(new EfCarDal());
            manager.Add(new Car
            {
                Id = 1,
                ColorId = 1,
                DailyPrice = 120,
                Description = "Lambo",
                BrandId = 1,
                ModelYear = new DateTime(1995, 12, 4)
            });
            foreach (var item in manager.GetAll())
            {
                Console.WriteLine(item.Description);
            }
        }
    }
}