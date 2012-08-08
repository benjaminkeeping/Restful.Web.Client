using System;
using System.Collections.Generic;
using System.Linq;
using Restful.Wiretypes;

namespace Restful.Web.Client.Errors
{
    public class HttpError : Exception
    {
        readonly IEnumerable<Error> _errors;
        readonly int _httpStatusCode;

        public HttpError(IEnumerable<Error> errors, int httpStatusCode) : base(Format(errors))
        {
            _errors = errors;
            _httpStatusCode = httpStatusCode;
        }

        private static string Format(IEnumerable<Error> errors)
        {
            return errors == null 
                ? "unknown error cause" 
                : string.Join(",", errors.Where(x => x != null).Select(x => string.Format("{0}:{1}", x.Key, x.Value)));
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
