using Store.G05.Domain.Entities.Products;
using Store.G05.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G05.Services.Specifications.Products
{
    public class ProductsCountSpecification :BaseSpecification<int, Product>
    {
        public ProductsCountSpecification(ProductQueryParameters parameters) :base(
            P =>
            (!parameters.BrandId.HasValue || P.BrandId == parameters.BrandId)
            && (!parameters.TypeId.HasValue || P.TypeId == parameters.TypeId)
            && (string.IsNullOrEmpty(parameters.Search) || P.Name.ToLower().Contains(parameters.Search.ToLower()))
            )
        {

            
        }
    }
}
