namespace Restful.Web.Client.Urls
{
    public interface IUrlBuilder
    {
        string Build(string urlfragment);
        string BuildPagedUrl(string urlFragment, int page, int size);
    }
}