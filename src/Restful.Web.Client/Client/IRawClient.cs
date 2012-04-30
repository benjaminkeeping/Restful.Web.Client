namespace Restful.Web.Client.Client
{
    public interface IRawClient
    {
        void MakeWebRequest(string url, string method);
        void MakeWebRequest(string url, string method, string body);
        string MakeWebRequestWithResult(string url, string method);
        string MakeWebRequestWithResult(string url, string method, string body);
    }
}