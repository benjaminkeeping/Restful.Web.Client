using Restful.Web.Client.Headers;
using Restful.Web.Client.Parsers;
using Restful.Web.Client.Urls;

namespace Restful.Web.Client.Client
{
    public class JsonWebClient : BaseWebClient
    {
        public JsonWebClient(string baseUrl)
            : base(baseUrl, new JsonTypeParser(), "application/json")
        {
            
        }

        public JsonWebClient(string baseUrl, IHeaderAppender headerAppender)
            : base(new UrlBuilder(baseUrl), new JsonTypeParser(), headerAppender, "application/json")
        {

        }
    }
}