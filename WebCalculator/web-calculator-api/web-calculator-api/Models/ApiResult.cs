using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_calculator_api.Models
{
    public class ApiResult
    {
        public int HttpStatusCode { get; set; }
        public string Result { get; set; }
        public bool HasError { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}
