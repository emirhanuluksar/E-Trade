using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Utilities.Results;
using Domain.Entities.Concrete;
using Infrastructure.Abstract;
using Persistence.Abstract;

namespace Infrastructure.Concrete
{
    public class StoreManager : IStoreService
    {
        IStoreDal _storeDal;
        public StoreManager(IStoreDal storeDal)
        {
            _storeDal = storeDal;
        }

        public IResult Add(Store store)
        {
            _storeDal.Add(store);
            return new SuccessResult();
        }

        public IResult Delete(Store store)
        {
            _storeDal.Delete(store);
            return new SuccessResult();
        }

        public IDataResult<List<Store>> GetAll()
        {
            return new SuccessDataResult<List<Store>>(_storeDal.GetAll());
        }

        public IResult Update(Store store)
        {
            _storeDal.Update(store);
            return new SuccessResult();
        }
    }
}