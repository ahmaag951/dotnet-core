using Newtonsoft.Json;
using System.IO;

namespace test_rest_sharp.RestSharp
{
    /// <summary>
    /// Helper that wraps Newtonsoft.Json serialization for use with RestSharp bodies.
    /// </summary>
    public class NewtonsoftJsonSerializer
    {
        private readonly JsonSerializer _serializer;

        public NewtonsoftJsonSerializer(JsonSerializer serializer)
        {
            _serializer = serializer;
        }

        public string Serialize(object obj)
        {
            using var sw = new StringWriter();
            using var writer = new JsonTextWriter(sw);
            _serializer.Serialize(writer, obj);
            return sw.ToString();
        }

        public static NewtonsoftJsonSerializer Default =>
            new NewtonsoftJsonSerializer(new JsonSerializer
            {
                NullValueHandling = NullValueHandling.Ignore
            });
    }
}
