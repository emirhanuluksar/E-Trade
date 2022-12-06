using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DataAccess.EntityFramework;
using Domain.Entities.Concrete;
using Persistence.Abstract;
using Persistence.Concrete.EntityFramework;

namespace Persistence.Concrete
{
    public class EfProductImageDal : EfEntityRepositoryBase<ProductImage, ETradeContext>, IProductImageDal
    {
        
    }
}