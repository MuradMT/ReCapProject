using Business.Abstract;
using Data_Access.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        readonly ICarDal _cardal;
        public CarManager(ICarDal cardal)
        {
           _cardal=cardal;
        }

        public void Add(Car car)
        {
            if (car.Description.Length >1&&car.DailyPrice>0)
            {
                _cardal.Add(car);

            }
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _cardal.GetCarDetails();
        }
        public int Len {
            get
            {
                return _cardal.GetCarDetails().Count;
            }
                }
        public void Delete(Car car)
        {
           _cardal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _cardal.GetAll();
        }

        public Car GetById(int id)
        {
            return _cardal.Get(p => p.Id == id);
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _cardal.GetAll(p=>p.BrandId==id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _cardal.GetAll(p => p.ColorId == id);
        }

        public void Update(Car car)
        {
            _cardal.Update(car);
        }
    }
}
