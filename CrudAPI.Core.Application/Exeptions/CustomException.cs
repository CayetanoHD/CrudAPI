using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CrudAPI.Core.Application.Exeptions
{
    public class CustomException : Exception
    {
        public List<string> ErrorMessages { get; }
        public HttpStatusCode StatusCode { get; }

        public CustomException(
            string message,
            List<string>? errorMessages = default,
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError
        )
            : base(message)
        {
            ErrorMessages = errorMessages;
            StatusCode = statusCode;
        }
    }
}
