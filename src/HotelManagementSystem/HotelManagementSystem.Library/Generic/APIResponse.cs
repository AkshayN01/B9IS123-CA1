using HotelManagementSystem.Contracts.Generic.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Library.Generic
{
    public static class APIResponse
    {
        public static HTTPResponse ConstructHTTPResponse(Object data, int retVal, string message)
        {
            return new HTTPResponse { Data = data, Meta = ConstructMeta(retVal, message) };
        }

        public static HTTPResponse ConstructExceptionResponse(int retVal, string message)
        {
            return new HTTPResponse() { Meta = ConstructMeta(retVal, message) };
        }

        private static HTTPMeta ConstructMeta(int retVal, string message)
        {
            return new HTTPMeta() { Message = message, RetVal = retVal };
        }
    }
}
