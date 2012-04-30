using System.Collections.Generic;
using Restful.Wiretypes;
namespace Restful.Web.Client.Errors
{
    public class Http403 : HttpError
    {
        public Http403(IEnumerable<Error> errors)
            : base(errors)
        {
        }
    }
}