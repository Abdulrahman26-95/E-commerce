using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad Request , You Have Made ",
                401 => "Authorized ! , I Think You Are Not ",
                404 => "Resources Are Not Found",
                500 => "Errors are the path to the dark side .Errors lead to anger ,Anger leads to hate , Hate leads to career change",
                // Default Case 
                _ => null
            };
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}