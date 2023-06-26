namespace Screenplay.Rest.Serialization
{
    internal interface ISerializer
    {
        string Serialize(object objectToSerialize);
    }
}
