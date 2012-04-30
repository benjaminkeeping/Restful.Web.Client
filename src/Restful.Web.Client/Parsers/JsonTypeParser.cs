using System;
using Newtonsoft.Json;

namespace Restful.Web.Client.Parsers
{
    public class JsonTypeParser : ITypeParser
    {
        public T From<T>(string objAsString)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(objAsString);
            }
            catch (Exception e)
            {
                throw new Exception("Errored reading json(" + objAsString + ")", e);
            }

        }

        public string To<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}