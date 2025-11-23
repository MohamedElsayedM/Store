using AutoMapper;
using Microsoft.Extensions.Configuration;
using Store.G05.Domain.Entities.Products;
using Store.G05.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G05.Services.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile(IConfiguration configuration)
        {
            CreateMap<Product, ProductResponce>()
                .ForMember(D => D.Brand, O => O.MapFrom(S => S.Brand.Name))
                .ForMember(D => D.Type, O => O.MapFrom(S => S.Type.Name))
                .ForMember(D => D.PictureUrl, O => O.MapFrom(S => $"{configuration["BaseUrl"]}{S.PictureUrl}")) ;

                CreateMap<ProductBrand, BrandTypeResponce>();
            CreateMap<ProductType, BrandTypeResponce>();
        }
    }
}
