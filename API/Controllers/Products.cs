using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// using API.Data;
// using API.Entities;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Products : ControllerBase
    {
        private readonly IProductRepository _repo;
        public Products(IProductRepository repo)
        {
            _repo = repo;
        }
        // Get All Products 
        [HttpGet]
        public async Task<ActionResult<List<Product>>> getAllProducts()
        {
            var p = await _repo.getProductsAsync();
            return Ok(p);
        }
        // Get Product By ID
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> getProductById(int id)
        {
            return await _repo.getProductByIdAsync(id);
        }
        // Get Brands 
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> getAllProductBrands()
        {
            return Ok(await _repo.getProductBrandsAsync());
        }
        // Get Product Types 
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> getAllProductTypes()
        {
            return Ok(await _repo.getProductTypesAsync());
        }
    }
}