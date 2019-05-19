using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_calculator_api.Models;
using web_calculator_api.Domain;
using Microsoft.AspNetCore.Cors;

namespace web_calculator_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalcController : ControllerBase
    {
        // GET: api/Calc
        [HttpGet]
        public ApiResult Get()
        {
            return new ApiResult
            {
                HttpStatusCode = 405,
                HasError = true,
                Result = null,
                ErrorMessages = new List<string> { "The only accepted HTTP verb is POST." }
            };
        }

        // GET: api/Calc/5
        [HttpGet("{id}", Name = "Get")]
        public ApiResult Get(int id)
        {
            return new ApiResult
            {
                HttpStatusCode = 405,
                HasError = true,
                Result = null,
                ErrorMessages = new List<string> { "The only accepted HTTP verb is POST." }
            };
        }

        // POST: api/Calc
        //[Route("api/calc/post")]
        [EnableCors("CorsPolicy")]
        [HttpPost]
        public ApiResult Post(ApiRequest request)
        {            
            var errorApiResult = new ApiResult
            {
                HttpStatusCode = 400,
                HasError = true
            };

            var value = request.Expression; 
            
            if(string.IsNullOrWhiteSpace(value))
            {
                errorApiResult.ErrorMessages = new List<string> { "Invalid input expression. An example of expected input is '4 * 7 + 10.5'" };
                return errorApiResult;
            }

            var result = Calculate.Process(value);

            if ( string.IsNullOrWhiteSpace(result))
            {
                errorApiResult.ErrorMessages = new List<string> { $"Could not evaluate expression: {value}" };
                return errorApiResult;
            }

            return new ApiResult
            {
                HttpStatusCode = 200,
                HasError = false,
                Result = result
            };

        }

        // PUT: api/Calc/5
        [HttpPut("{id}")]
        public ApiResult Put(int id, [FromBody] string value)
        {
            return new ApiResult
            {
                HttpStatusCode = 405,
                HasError = true,
                Result = null,
                ErrorMessages = new List<string> { "The only accepted HTTP verb is POST." }
            };
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ApiResult Delete(int id)
        {
            return new ApiResult
            {
                HttpStatusCode = 405,
                HasError = true,
                Result = null,
                ErrorMessages = new List<string> { "The only accepted HTTP verb is POST." }
            };
        }
    }
}
