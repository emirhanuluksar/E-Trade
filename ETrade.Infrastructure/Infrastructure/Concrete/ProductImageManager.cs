using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Utilities.Business;
using Application.Utilities.Helpers.FileHelper;
using Application.Utilities.Results;
using Domain.Entities.Concrete;
using Infrastructure.Abstract;
using Infrastructure.Constants;
using Microsoft.AspNetCore.Http;
using Persistence.Abstract;

namespace Infrastructure.Concrete
{
    public class ProductImageManager : IProductImageService
    {
        IProductImageDal _productImageDal;
        IFileHelper _fileHelper;

        public ProductImageManager(IProductImageDal productImageDal, IFileHelper fileHelper)
        {
            _productImageDal = productImageDal;
            _fileHelper = fileHelper;
        }
        public IResult Add(IFormFile file, ProductImage productImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimit(productImage.ProductId));
            if (result != null)
            {
                return result;
            }
            productImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagePath);
            _productImageDal.Add(productImage);
            return new SuccessResult("Ekleme işlemi başarılı");
        }

        public IResult Delete(ProductImage productImage)
        {
            _fileHelper.Delete(PathConstants.ImagePath + productImage.ImagePath);
            _productImageDal.Delete(productImage);
            return new SuccessResult("Silme işlemi başarılı");
        }

        public IDataResult<List<ProductImage>> GetAll()
        {
            return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll());
        }

        public IDataResult<ProductImage> GetById(int imageId)
        {
            return new SuccessDataResult<ProductImage>(_productImageDal.Get(p => p.Id == imageId));
        }

        public IDataResult<List<ProductImage>> GetByProductId(int productId)
        {
            IResult result = BusinessRules.Run(CheckIfHaveCarImage(productId));
            if(result != null)
            {
                return new ErrorDataResult<List<ProductImage>>(GetDefaultImage(productId).Data);
            }
            return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll(p=>p.ProductId == productId));
        }

        public IResult Update(IFormFile file, ProductImage productImage)
        {
            productImage.ImagePath = _fileHelper.Update(file, PathConstants.ImagePath + productImage.ImagePath, PathConstants.ImagePath);
            _productImageDal.Update(productImage);
            return new SuccessResult();
        }



        private IResult CheckIfCarImageLimit(int productId)
        {
            var result = _productImageDal.GetAll(p => p.ProductId == productId);
            if (result.Count >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        private IResult CheckIfHaveCarImage(int productId)
        {
            var result = _productImageDal.GetAll(p => p.ProductId == productId);
            if (result.Count > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
        private IDataResult<List<ProductImage>> GetDefaultImage(int productId)
        {
            List<ProductImage> productImage = new List<ProductImage>();
            productImage.Add(new ProductImage { ProductId = productId, ImagePath = "DefaultImage.jpg" });
            return new SuccessDataResult<List<ProductImage>>(productImage);
        }
    }
}