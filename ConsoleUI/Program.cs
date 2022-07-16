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
            //RentalTest();

        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            Console.WriteLine(rentalManager.Add(new Rental()
            {
                Id = 7,
                CarId = 3,
                CustomerId = 1,
                RentDate = DateTime.Now
            }).Message);
        }

        private static void CarDtoTest()
        {
            CarManager manager = new CarManager(new EfCarDal());
            Console.WriteLine("Total Cars:" + manager.Len);
            foreach (var item in manager.GetCarDetails().Data)
            {
                Console.WriteLine(item.CarName + "/" + item.ColorName + "/" + item.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager manager = new CarManager(new EfCarDal());
            if (manager.GetAll().Success)
            {

                Console.WriteLine(manager.GetById(5).Data.Description);
                Console.WriteLine(manager.GetById(5).Message);
            }
            else
            {
                Console.WriteLine(manager.GetAll().Message);
            }
        }
    }
}