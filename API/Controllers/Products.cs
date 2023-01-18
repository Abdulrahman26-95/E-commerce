using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using AutoMapper;
// using API.Data;
// using API.Entities;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    // [ApiController]
    // [Route("api/[controller]")]
    public class Products : BaseController
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _brandRepo;
        private readonly IGenericRepository<ProductType> _typeRepo;
        private readonly IMapper _mapper;
        public Products
        (
        IGenericRepository<Product> productRepo,
        IGenericRepository<ProductBrand> brandRepo,
        IGenericRepository<ProductType> typeRepo,
        IMapper mapper)
        {
            _productRepo = productRepo;
            _brandRepo = brandRepo;
            _typeRepo = typeRepo;
            _mapper = mapper;
        }
        // Get All Products 
        [HttpGet]
        public async Task<ActionResult<List<ProductToReturnDto>>> getAllProducts()
        {
            var spec = new ProductsWithTypesAndBrandsSpecifications();

            var products = await _productRepo.ListAsync(spec);

            return Ok(_mapper
                            .Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products));
        }
        // Get Product By ID
        [HttpGet("{id:int}")]
        // Give swagger a hint about we return in response
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> getProductById(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecifications(id);
            var product = await _productRepo.GetEntityWithSpec(spec);
            if (product == null) return NotFound(new ApiResponse(404));
            return _mapper.Map<Product, ProductToReturnDto>(product);
        }
        // Get Brands 
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> getAllProductBrands()
        {
            return Ok(await _brandRepo.getAllAsync());
        }
        // Get Product Types 
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> getAllProductTypes()
        {
            return Ok(await _typeRepo.getAllAsync());
        }
    }
}