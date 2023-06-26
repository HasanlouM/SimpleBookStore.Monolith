namespace Screenplay.Core.Models.Questions
{
    public static class Remember
    {
        public static IQuestion<T> ValueOf<T>(string key)
        {
            return new Remember<T>(key);
        }
    }
}
