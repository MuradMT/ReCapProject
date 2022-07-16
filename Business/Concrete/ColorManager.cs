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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color brand)
        {
            _colorDal.Add(brand);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Color brand)
        {
            _colorDal.Delete(brand);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
           return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<Color> GetById(int id)
        {
           return new SuccessDataResult<Color>(_colorDal.Get(p=>p.Id==id));
        }

        public IResult Update(Color brand)
        {
            _colorDal.Update(brand);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
