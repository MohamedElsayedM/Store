using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.G05.Services.Abstractions;
using Store.G05.Shared.Dtos;
using Store.G05.Shared.ErrorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G05.Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IServiceManger _serviceManger) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK,Type =typeof(PaginationResponce<ProductResponce>))]
        [ProducesResponseType(StatusCodes.Status404NotFound,Type =typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError,Type =typeof(ErrorDetails))]
        public async Task<ActionResult<PaginationResponce<ProductResponce>>> GetAllProducts([FromQuery] ProductQueryParameters parameters)
        {
            var result = await _serviceManger.ProductService.GetAllProductsAsync(parameters);
            if (result is null) return BadRequest();
            return Ok(result);

        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductResponce))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetails))]
        public async Task<ActionResult<ProductResponce>> GetProductById(int? id)
        {
            if (id is null) return BadRequest();
            var result = await _serviceManger.ProductService.GetProductByIDAsync(id.Value);
            if (result is null) return BadRequest();
            return Ok(result);
        }

        [HttpGet("brands")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BrandTypeResponce>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetails))]
        public async Task<ActionResult<BrandTypeResponce>> GetAllBrands()
        {
            var result = await _serviceManger.ProductService.GetAllBrandsAsync();
            if (result is null) return BadRequest();
            return Ok(result);

        }

        [HttpGet("types")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BrandTypeResponce>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetails))]
        public async Task<ActionResult<BrandTypeResponce>> GetAlltypes()
        {
            var result = await _serviceManger.ProductService.GetAllTypesAsync();
            if (result is null) return BadRequest();
            return Ok(result);

        }
    }
}
