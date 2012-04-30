using System;
using System.Collections.Generic;
using Restful.Wiretypes;

namespace Restful.Web.Client.Errors
{
    public class HttpError : Exception
    {
        readonly IEnumerable<Error> _errors;

        public HttpError(IEnumerable<Error> errors)
        {
            _errors = errors;
        }

        public IEnumerable<Error> Errors
        {
            get { return _errors; }
        }
    }
}
