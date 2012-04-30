using System.Collections.Generic;
using Restful.Wiretypes;

namespace Restful.Web.Client.Errors
{
    public class Http500 : HttpError
    {
        public Http500(IEnumerable<Error> errors)
            : base(errors)
        {
        }
    }
}