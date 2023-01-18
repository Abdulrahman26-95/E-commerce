using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuggyController : ControllerBase
    {
        private readonly StoreContext _context;
        public BuggyController(StoreContext context)
        {
            _context = context;
        }
        // NotFound Error
        [HttpGet("notFound")]
        public ActionResult GetNotFoundRequest()
        {
            var thing = _context.Products.Find(1000);
            if (thing == null)
                return NotFound(new ApiResponse(404));
            else
                return Ok();
        }
        // Server Error
        [HttpGet("serverError")]
        public ActionResult GetServerError()
        {
            var thing = _context.Products.Find(1000);
            var thingToReturn = thing.ToString();
            // It will generate an Exception because it can not excute ToString Method on Something it does not exsit.
            return Ok();
        }
        // Bad Request
        [HttpGet("badRequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }
        // Bad Request => Validation Errors
        [HttpGet("badRequest/{id}")]
        public ActionResult GetBadRequest(int id)
        {
            return BadRequest();
        }
    }
}