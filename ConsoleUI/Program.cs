using Business.Concrete;
using Data_Access.Concrete.InMemory;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager manager=new CarManager(new InMemoryCarDal());
            foreach (var item in manager.Back())
            {
                Console.WriteLine(item.Description);
            }
        }
    }
}