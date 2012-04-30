using System.Net;

namespace Restful.Web.Client.Errors
{
    public class HttpWebResponseWasNull : HttpException
    {
        public HttpWebResponseWasNull(string url)
            : base(url, HttpStatusCode.InternalServerError, string.Empty)
        {
        }
    }

}