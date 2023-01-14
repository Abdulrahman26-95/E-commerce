using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// using API.Data;
// using API.Entities;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Products : ControllerBase
    {
        private readonly StoreContext _context;
        public Products(StoreContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> getAllProducts()
        {
            var p = await _context.Products.ToListAsync();
            if (p != null)
                return Ok(p);
            else
                return NotFound();
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> getProduct(int id)
        {
            // var p = _context.Products.SingleOrDefault(p => p.Id == id);
            // if (p != null)
            //     return Ok(p);
            // else
            //     return NotFound();
            return await _context.Products.FindAsync(id);
        }
    }
}