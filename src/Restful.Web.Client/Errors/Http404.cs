using System.Collections.Generic;
using Restful.Wiretypes;

namespace Restful.Web.Client.Errors
{
    public class Http404 : HttpError
    {
        public Http404(IEnumerable<Error> errors)
            : base(errors, 404)
        {
        }
    }
}