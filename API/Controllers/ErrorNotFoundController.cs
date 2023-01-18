using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("errorNotFound/{code}")]

    // To Fix Swagger 
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorNotFoundController : BaseController
    {
        // End Points Does Not Exsit Error 
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
        //Then we use Midlewarein stratup Class ( app.UseStatusCodePagesWithRedirects("/errors/{0}"); ) 
        // When We take an endpoints we dont have
    }
}