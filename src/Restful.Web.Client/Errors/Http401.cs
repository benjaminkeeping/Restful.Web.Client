using System.Collections.Generic;
using Restful.Wiretypes;

namespace Restful.Web.Client.Errors
{
    public class Http401 : HttpError
    {
        public Http401(IEnumerable<Error> errors)
            : base(errors, 401)
        {
        }
    }
}