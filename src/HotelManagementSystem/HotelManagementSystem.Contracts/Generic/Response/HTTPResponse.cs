using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Contracts.Generic.Response
{
    public class HTTPResponse
    {
        public Object Data { get; set; } = default(Object);
        public HTTPMeta Meta { get; set; } = new HTTPMeta();
    }

    public class HTTPMeta
    {
        public int RetVal { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
