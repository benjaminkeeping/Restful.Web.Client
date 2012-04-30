using System.Collections.Generic;
using Restful.Wiretypes;

namespace Restful.Web.Client.Errors
{
    public class Http400 : HttpError
    {
        public Http400(IEnumerable<Error> errors) : base(errors)
        {
        }
    }
}