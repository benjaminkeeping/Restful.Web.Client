using System;
using System.Net;

namespace Restful.Web.Client.Errors
{
    public class HttpException: Exception
    {
        readonly HttpStatusCode _statusCode;
        readonly string _body;

        public HttpException(string url, HttpStatusCode statusCode, string body)
            : base(string.Format("Error calling {0}", url))
        {
            _statusCode = statusCode;
            _body = body;
        }

        public string Body
        {
            get { return _body ?? string.Empty; }
        }

        public HttpStatusCode StatusCode
        {
            get { return _statusCode; }
        }
    }
}