using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Utilities.Results;
using Domain.Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Abstract
{
    public interface IProductImageService
    {
        IDataResult<List<ProductImage>> GetByProductId(int productId);
        IDataResult<List<ProductImage>> GetAll();
        IDataResult<ProductImage> GetById(int imageId);
        IResult Add(IFormFile file, ProductImage productImage);
        IResult Update(IFormFile file, ProductImage productImage);
        IResult Delete(ProductImage productImage);
    }
}