namespace Restful.Web.Client.Client
{
    public interface IWebClient
    {
        T Get<T>(string urlFragment);
        void Post<T>(string urlFragment, T body);
        void Put<T>(string urlFragment, T body);
        void Delete(string urlFragment);
        TDown PostWithResponse<TDown>(string urlFragment);
        T PostWithResponse<T>(string urlFragment, T body);
        TDown PostWithResponse<TUp, TDown>(string urlFragment, TUp body);
        TDown PutWithResponse<TDown>(string urlFragment);        
        T PutWithResponse<T>(string urlFragment, T body);        
        TDown PutWithResponse<TUp, TDown>(string urlFragment, TUp body);
        T DeleteWithResponse<T>(string urlFragment);
    }
}