using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Utilities.Results;
using Domain.Entities.Concrete;

namespace Infrastructure.Abstract
{
    public interface IStoreService
    {
        IDataResult<List<Store>> GetAll();
        IResult Add(Store store);
        IResult Delete(Store store);
        IResult Update(Store store);
    }
}