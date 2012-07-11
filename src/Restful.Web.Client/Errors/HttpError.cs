using System;
using System.Collections.Generic;
using Restful.Wiretypes;

namespace Restful.Web.Client.Errors
{
    public class HttpError : Exception
    {
        readonly IEnumerable<Error> _errors;
        readonly int _httpStatusCode;

        public HttpError(IEnumerable<Error> errors, int httpStatusCode)
        {
            _errors = errors;
            _httpStatusCode = httpStatusCode;
        }

        public int HttpStatusCode
        {
            get { return _httpStatusCode; }
        }

        public IEnumerable<Error> Errors
        {
            get { return _errors; }
        }
    }
}
