using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Utilities.Results;
using Domain.Entities.Concrete;
using Infrastructure.Abstract;
using Infrastructure.Constants;
using Persistence.Abstract;

namespace Infrastructure.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<List<Category>> GetAll()
        {
            var result = _categoryDal.GetAll();
            if(result != null)
            {
                return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(), Messages.CategoryListed);
            }
            return new ErrorDataResult<List<Category>>();
            //return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(), Messages.CategoryListed);
        }

        public IDataResult<Category> GetById(int categoryId)
        {
            var result = _categoryDal.Get(c=>c.CategoryId == categoryId);
            if(result != null)
            {
                return new SuccessDataResult<Category>(result);
            }
            return new ErrorDataResult<Category>();
        }
    }
}