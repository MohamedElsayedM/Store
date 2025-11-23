using AutoMapper;
using Store.G05.Domain.Contracts;
using Store.G05.Services.Abstractions;
using Store.G05.Services.Abstractions.Products;
using Store.G05.Services.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G05.Services
{
    public class ServiceManger(IUnitOfWork _unitOfWork, IMapper _mapper) : IServiceManger
    {
        public IProductService ProductService { get; } = new ProductService(_unitOfWork,_mapper);
    }
}
