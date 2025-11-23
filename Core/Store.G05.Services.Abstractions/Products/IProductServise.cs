using Store.G05.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G05.Services.Abstractions.Products
{
    public interface IProductService
    {
        Task<PaginationResponce<ProductResponce>> GetAllProductsAsync(ProductQueryParameters parameters);
        Task<ProductResponce> GetProductByIDAsync(int Id);
        Task<IEnumerable<BrandTypeResponce>> GetAllBrandsAsync();
        Task<IEnumerable<BrandTypeResponce>> GetAllTypesAsync();

    }
}