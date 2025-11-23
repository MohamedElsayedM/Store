using Store.G05.Domain.Entities.Products;
using Store.G05.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.G05.Services.Specifications.Products
{
    public class ProductwithBrandTypeSpecification : BaseSpecification<int,Product>
    {
        public ProductwithBrandTypeSpecification(int id) : base(P => P.Id==id)
        {
            Includes.Add(P => P.Brand);
            Includes.Add(P => P.Type);
        }

        public ProductwithBrandTypeSpecification(ProductQueryParameters parameters) : base
            ( P => 
            (!parameters.BrandId.HasValue || P.BrandId == parameters.BrandId) 
            && (!parameters.TypeId.HasValue || P.TypeId == parameters.TypeId) 
            && (string.IsNullOrEmpty(parameters.Search) || P.Name.ToLower().Contains(parameters.Search.ToLower())) 
            )
        {
            if (string.IsNullOrEmpty(parameters.Sort))
            {
                ApplyOrderBy(P => P.Name);
            }
            else
            {
                switch (parameters.Sort.ToLower()) {
                    case "priceasc": 
                        ApplyOrderBy(P => P.Price); 
                        break;
                    case "pricedsc":
                        ApplyOrderByDesc(P => P.Price);
                        break;
                    default:
                        ApplyOrderBy(P => P.Name);
                        break;
                }
            }

            Includes.Add(P => P.Brand);
            Includes.Add(P => P.Type);
            ApplyPagination(parameters.PageIndex, parameters.PageSize);
        }
    }
}
