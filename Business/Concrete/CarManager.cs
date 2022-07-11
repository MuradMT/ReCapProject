using Business.Abstract;
using Data_Access.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _cardal;
        public CarManager(ICarDal cardal)
        {
            _cardal = cardal;
        }

        public void Add(Car car)
        {
            if (car.Description.Length >1&&car.DailyPrice>0)
            {
                _cardal.Add(car);
            }
        }

        public List<Car> GetAll()
        {
            return _cardal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _cardal.GetAll(p=>p.BrandId==id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _cardal.GetAll(p => p.ColorId == id);
        }
    }
}
