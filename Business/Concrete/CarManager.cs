using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IResult Add(Car car)
        {
            if (car.Description.Length >1&&car.DailyPrice>0)
            {
                _cardal.Add(car);
               

            }
            return new SuccessResult(Messages.Added="Car");
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_cardal.GetCarDetails(),Messages.Get="Car Details");
        }
        public int Len {
            get
            {
                return _cardal.GetCarDetails().Count;
            }
                }
        public IResult Delete(Car car)
        {
           _cardal.Delete(car);
            return new SuccessResult(Messages.Deleted = "Car");
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_cardal.GetAll(),Messages.Get="Cars");
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_cardal.Get(p => p.Id == id),
                Messages.Get="Car matching by Id");
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_cardal.GetAll(p=>p.BrandId==id),
                Messages.Get = "Cars matching by BrandId");
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_cardal.GetAll(p => p.ColorId == id),
                Messages.Get = "Cars matching by ColorId");
        }

        public IResult Update(Car car)
        {
            _cardal.Update(car);
            return new SuccessResult(Messages.Updated="Car");
        }
    }
}
