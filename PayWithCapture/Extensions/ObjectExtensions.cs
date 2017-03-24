using System.Xml.Linq;
using System.Xml.Serialization;

namespace PayWithCapture.Extensions
{
    public static class ObjectExtensions
    {
        public static T ToObject<T>(this XElement xml)
        {
            T obj = System.Activator.CreateInstance<T>();
            var serializer = new XmlSerializer(typeof(T));
            obj = (T)serializer.Deserialize(xml.CreateReader());
            return obj;
        }

        public static string ToJson(this object obj, bool indented = false)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj, indented ? Newtonsoft.Json.Formatting.Indented : Newtonsoft.Json.Formatting.None);
        }

        public static string ToUrlFormEncoding(this object obj)
        {
            return Helpers.Api.UrlFormEncode(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
        }
    }
}
