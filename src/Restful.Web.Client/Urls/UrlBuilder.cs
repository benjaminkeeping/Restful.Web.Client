using System.Diagnostics;

namespace Restful.Web.Client.Urls
{
    public class UrlBuilder : IUrlBuilder
    {
        readonly string _baseUrl;

        public UrlBuilder(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        #region IUrlBuilder Members

        public string Build(string urlfragment)
        {
            var url = string.Format("{0}/{1}", _baseUrl, urlfragment);
            Trace.WriteLine(url);
            return url;
        }

        public string BuildPagedUrl(string urlFragment, int page, int size)
        {
            return Build(urlFragment) + string.Format("?page={0}&size={1}", page, size);
        }

        #endregion
    }
}