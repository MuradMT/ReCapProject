using Business.Concrete;
using Data_Access.Concrete.EntityFrameWork;
using Data_Access.Concrete.InMemory;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager manager=new CarManager(new EfCarDal());
            foreach (var item in manager.GetAll())
            {
                Console.WriteLine(item.BrandId);
            }
        }
    }
}