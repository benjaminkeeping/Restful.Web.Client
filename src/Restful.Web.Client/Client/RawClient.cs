using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Restful.Web.Client.Errors;
using Restful.Web.Client.Headers;

namespace Restful.Web.Client.Client
{
    public class RawClient : IRawClient
    {
        readonly IHeaderAppender _headerAppender;
        readonly string _contentType;

        public RawClient(IHeaderAppender headerAppender, string contentType)
        {
            _headerAppender = headerAppender;
            _contentType = contentType;
        }

        #region IWebClient Members

        public void MakeWebRequest(string url, string method)
        {
            MakeWebRequest(url, method, "");
        }

        public void MakeWebRequest(string url, string method, string body)
        {
            TryWebRequest(
                url, method, request =>
                {
                    AddRequestBody(body, request);
                    var response = InitiateRequest(request);
                    ParseResponseAsString(response);
                });
        }

        public string MakeWebRequestWithResult(string url, string method)
        {
            return MakeWebRequestWithResult(url, method, "");
        }

        public string MakeWebRequestWithResult(string url, string method, string body)
        {
            return TryWebRequest(
                url, method, request =>
                {
                    AddRequestBody(body, request);
                    return InitiateRequest(request);
                });
        }

        #endregion

        static WebResponse InitiateRequest(WebRequest request)
        {
            var response = request.GetResponse();
            var status = ((HttpWebResponse)response).StatusCode;
            if (Convert.ToInt32(status) >= 400) throw new Exception("Error making request");
            return response;
        }

        void TryWebRequest(string url, string method, Action<WebRequest> webRequest)
        {
            try
            {
                var request = BuildRequest(url, method);
                webRequest(request);
            }
            catch (Exception ex)
            {
                throw ExtractWebResponseFromException(url, ex);
            }
        }

        string TryWebRequest(string url, string method, Func<WebRequest, WebResponse> makeWebRequest)
        {
            try
            {
                var request = BuildRequest(url, method);
                var response = makeWebRequest(request);
                return ParseResponseAsString(response);
            }
            catch (Exception ex)
            {
                throw ExtractWebResponseFromException(url, ex);
            }
        }

        static Exception ExtractWebResponseFromException(string url, Exception exception)
        {
            if (exception.GetType() != typeof(WebException)) return exception;
            // 401, 404, 500
            var response = ((WebException)exception).Response;
            if (response == null)
            {
                return new HttpWebResponseWasNull(url);
            }

            var status = ((HttpWebResponse)response).StatusCode;
            var body = ParseResponseAsString(response);
            return new HttpException(url, status, body);
        }

        static string ParseResponseAsString(WebResponse response)
        {
            using (var responseStream = response.GetResponseStream())
            {
                if (responseStream == null) throw new Exception("Invalid response");
                using (var reader = new StreamReader(responseStream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        static void AddRequestBody(string body, WebRequest request)
        {
            request.ContentType = "application/json";
            if (string.IsNullOrWhiteSpace(body)) return;
            using (var requestStream = request.GetRequestStream())
            {
                using (var writer = new StreamWriter(requestStream))
                {
                    writer.Write(body);
                }
            }
        }

        HttpWebRequest BuildRequest(string url, string method)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = _contentType;
            _headerAppender.AppendTo(request);
            request.Method = method;
            request.KeepAlive = true;
            return request;
        }

    }
}