using AutoMapper;
using Store.G05.Domain.Contracts;
using Store.G05.Domain.Entities.Products;
using Store.G05.Domain.Exceptions;
using Store.G05.Services.Abstractions.Products;
using Store.G05.Services.Specifications.Products;
using Store.G05.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G05.Services.Products
{
    public class ProductService(IUnitOfWork _unitOfWork, IMapper _mapper) : IProductService
    {
        public async Task<PaginationResponce<ProductResponce>> GetAllProductsAsync(ProductQueryParameters parameters)
        {

            var spec = new ProductwithBrandTypeSpecification(parameters);
             var products = await _unitOfWork.GetRepository<int, Product>().GetAllAsync(spec);
            var result = _mapper.Map<IEnumerable<ProductResponce>>(products);
            var countSpec = new ProductsCountSpecification(parameters);
            var totalCount = await _unitOfWork.GetRepository<int, Product>().GetTotalCountAsync(countSpec);

            return new PaginationResponce<ProductResponce>(parameters.PageIndex,parameters.PageSize,totalCount, result);
        }
        public async Task<ProductResponce> GetProductByIDAsync(int Id)
        {
          var product = await _unitOfWork.GetRepository<int, Product>().GetAsync(Id);
            if (product is null) throw new ProductNotFoundException(Id);
          var result = _mapper.Map<ProductResponce>(product);
        return result;
        }

        public async Task<IEnumerable<BrandTypeResponce>> GetAllBrandsAsync()
        {
            var brands = await _unitOfWork.GetRepository<int, ProductBrand>().GetAllAsync();
            var result = _mapper.Map<IEnumerable<BrandTypeResponce>>(brands);
            return result;
        }

        public async Task<IEnumerable<BrandTypeResponce>> GetAllTypesAsync()
        {
            var types = await _unitOfWork.GetRepository<int, ProductType>().GetAllAsync();
            var result = _mapper.Map<IEnumerable<BrandTypeResponce>>(types);
            return result;
        }

    }
}
