﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Attributes;
using Services.Abstractions;
using Shared;
using Shared.ErrorModels;

namespace Presentation
{
    // Api Controller
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IServiceManager serviceManager) : ControllerBase
    {
        // endpoint: public not-static method

        // sort : nameasc (default)
        // sort : namedesc
        // sort : priceasc
        // sort : pricdesc
        // filter : brandId, typeId
        [HttpGet] // GET: /api/products
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponse<ProductDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDetails))]
        [Cache(100)]
        [Authorize]
        public async Task<ActionResult<PaginationResponse<ProductDto>>> GetAllProducts([FromQuery] ProductSpecificationsParameters specParams)
        {
            var result = await serviceManager.ProductService.GetAllProductsAsync(specParams);
            return Ok(result); // 200
        }

        [HttpGet("{id}")] // GET: /api/products/12
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetails))]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var result = await serviceManager.ProductService.GetProductByIdAsync(id);
            return Ok(result); // 200
        }

        [HttpGet("types")] // GET: /api/products/types
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TypeDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDetails))]
        public async Task<ActionResult<IEnumerable<TypeDto>>> GetAllTypes()
        {
            var result = await serviceManager.ProductService.GetAllTypesAsync();
            if (result is null) return BadRequest();
            return Ok(result);
        }

        [HttpGet("brands")] // GET: /api/products/brands
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BrandDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDetails))]
        public async Task<ActionResult<IEnumerable<BrandDto>>> GetAllBrands()
        {
            var result = await serviceManager.ProductService.GetAllBrandsAsync();
            if (result is null) return BadRequest();
            return Ok(result);
        }
    }
}
