using System.Net;

namespace Restful.Web.Client.Headers
{
    public class NoOpHeaderAppender : IHeaderAppender
    {
        public void AppendTo(WebRequest request)
        {
        }
    }
}