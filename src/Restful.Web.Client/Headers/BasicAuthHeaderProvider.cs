using System;
using System.Linq;
using System.Net;
using System.Text;

namespace Restful.Web.Client.Headers
{
    public class BasicAuthHeaderProvider : IHeaderAppender
    {
        readonly string _username;
        readonly string _password;

        public BasicAuthHeaderProvider(string username, string password)
        {
            _username = username;
            _password = password;
        }

        public void AppendTo(WebRequest request)
        {
            if (request.Headers.AllKeys.Any(p => p.Equals("Authorization", StringComparison.InvariantCultureIgnoreCase)))
                return;

            var token = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", _username, _password)));
            var authHeader = string.Format("Basic {0}", token);
            request.Headers.Add("Authorization", authHeader);
        }
    }
}
