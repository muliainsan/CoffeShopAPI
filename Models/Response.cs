using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CoffeShop.Models
{
    public class Response<T>
    {
        public Response()
        {
            Status = HttpStatusCode.OK;
        }

        public HttpStatusCode Status { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }
    }
}
