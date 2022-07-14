using Core.Entity_Framework;
using Data_Access.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Concrete.EntityFrameWork
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapProjectContext context=new ReCapProjectContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join p in context.Colors on c.ColorId equals p.Id
                             select new CarDetailDto
                             {
                                 BrandName = b.Name,
                                 CarName = c.Description,
                                 ColorName = p.Name,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();
            }
            
        }
    }
}
