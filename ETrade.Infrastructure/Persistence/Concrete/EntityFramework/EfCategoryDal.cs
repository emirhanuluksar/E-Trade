using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DataAccess.EntityFramework;
using Domain.Entities.Concrete;
using Persistence.Abstract;

namespace Persistence.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, ETradeContext>, ICategoryDal
    {
        
    }
}