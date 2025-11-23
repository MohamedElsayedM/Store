using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G05.Shared.ErrorModels
{
    public class ValidationErrorResponce
    {
        public int statusCode { get; set; } = StatusCodes.Status400BadRequest;
        public string ErrorMessage { get; set; } = "Validation Error";
        public IEnumerable<ValidationError> Errors { get; set; }
    }
}
