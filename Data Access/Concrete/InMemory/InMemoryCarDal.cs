using Data_Access.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars= new List<Car>()
            {
                new Car(){Id=1,BrandId=1,DailyPrice=100,ColorId=1,Description="Mercedes",
                ModelYear=new DateTime(1955,12,6)},
                new Car(){Id=2,BrandId=2,DailyPrice=150,ColorId=2,Description="Ferrari",
                ModelYear=new DateTime(1935,2,16)},
                new Car(){Id=2,BrandId=2,DailyPrice=200,ColorId=2,Description="Lamborgini",
                ModelYear=new DateTime(1965,8,5)},
                new Car(){Id=4,BrandId=4,DailyPrice=300,ColorId=3,Description="Bugatti",
                ModelYear=new DateTime(1925,3,9)},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var item=_cars.SingleOrDefault(c=>c.Id==car.Id);
            _cars.Remove(item);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int car)
        {
            var item = _cars.SingleOrDefault(c => c.Id == car);
            return item;
        }

        public void Update(Car car)
        {
            var item = _cars.SingleOrDefault(c => c.Id == car.Id);
            item.Id = car.Id;
            item.BrandId = car.BrandId;
            item.ModelYear=car.ModelYear;
            item.DailyPrice=car.DailyPrice;
            item.Description=car.Description;
            item.ColorId=car.ColorId;
        }
    }
}
