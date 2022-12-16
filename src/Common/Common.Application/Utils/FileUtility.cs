using Microsoft.AspNetCore.Http;

namespace Common.Application.Utils
{
    public static class FileUtility
    {
        public static byte[] ToByte(this IFormFile file)
        {
            var stream = file.OpenReadStream();
            using var memoryStream = new MemoryStream();
            stream.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
