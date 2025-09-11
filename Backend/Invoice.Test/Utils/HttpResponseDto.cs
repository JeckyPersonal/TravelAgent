using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Test.Utils
{
    internal class HttpResponseDto
    {
        public HttpResponseDto(HttpStatusCode status, string content)
        {
            Status = status;
            Content = content;
        }

        public HttpStatusCode Status { get; private set; }
        public string Content { get; private set; }

    }
}
