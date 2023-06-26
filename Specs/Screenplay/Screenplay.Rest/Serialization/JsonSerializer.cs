using Newtonsoft.Json;

namespace Screenplay.Rest.Serialization
{
    internal class JsonSerializer : ISerializer
    {
        public string Serialize(object objectToSerialize)
        {
            return JsonConvert.SerializeObject(objectToSerialize);
        }
    }
}