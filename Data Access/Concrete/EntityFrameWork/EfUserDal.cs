using Core.Data_Access;
using Core.Entity_Framework;
using Data_Access.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Concrete.EntityFrameWork
{
    public class EfUserDal:EfEntityRepositoryBase<User,ReCapProjectContext>,IUserDal
    {

    }
}
