﻿using Business.Abstract;
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

    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
           _brandDal.Add(brand);
            return new SuccessResult(Messages.Added = "Brand");
        }

        public IResult Delete(Brand brand)
        {
           _brandDal.Delete(brand);
            return new SuccessResult(Messages.Deleted = "Brand");

        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),
                Messages.Get="Brands");
        }

        public IDataResult<Brand> GetById(int id)
        {
           return new SuccessDataResult<Brand>(_brandDal.Get(p => p.Id == id),
               Messages.Get="Brand matching by id");
        }

        public IResult Update(Brand brand)
        {
           _brandDal.Update(brand);
            return new SuccessResult(Messages.Updated = "Brand");

        }
    }
}
