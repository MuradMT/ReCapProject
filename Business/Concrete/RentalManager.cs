using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Data_Access.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            bool contain = false;
            foreach (var item in _rentalDal.GetAll())
            {
                if (rental.Id == item.Id)
                {
                    contain = true;
                    return new ErrorResult(Messages.ContainedId);
                }
            }
            if (contain == false)
            {
                bool carStillRent = false;
                foreach (var item in _rentalDal.GetAll())
                {
                    if (rental.CarId == item.CarId)
                    {
                        if (DateTime.Compare(
                            Convert.ToDateTime(item.ReturnDate??item.RentDate),DateTime.Now)>0)
                        {
                            carStillRent=true;
                        }
                    }
                }
                if (carStillRent)
                {
                    return new ErrorResult(Messages.CarNotCome);

                }
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == rentalId));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
