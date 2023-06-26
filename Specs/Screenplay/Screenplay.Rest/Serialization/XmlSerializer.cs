using YAXLib;

namespace Screenplay.Rest.Serialization
{
    internal class XmlSerializer :ISerializer
    {
        public string Serialize(object objectToSerialize)
        {
            YAXSerializer serializer = new YAXSerializer(objectToSerialize.GetType());
            return serializer.Serialize(objectToSerialize);
        }
    }
}