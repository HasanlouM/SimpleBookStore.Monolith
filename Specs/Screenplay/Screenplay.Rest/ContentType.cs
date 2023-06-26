using System.ComponentModel;

namespace Screenplay.Rest
{
    internal enum ContentType
    {
        [Description(MediaTypes.ApplicationJson)] Json = 0,
        [Description(MediaTypes.ApplicationXml)] Xml =1,
        [Description(MediaTypes.PlainText)] PlainText =2,
    }
}
