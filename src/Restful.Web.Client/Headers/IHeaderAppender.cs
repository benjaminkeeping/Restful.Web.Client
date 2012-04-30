using System.Net;

namespace Restful.Web.Client.Headers
{
    public interface IHeaderAppender
    {
        void AppendTo(WebRequest request);
    }

}