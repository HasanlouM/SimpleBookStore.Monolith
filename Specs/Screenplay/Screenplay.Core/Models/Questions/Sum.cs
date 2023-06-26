namespace Screenplay.Core.Models.Questions
{
    public static class Sum
    {
        public static IQuestion<long> Of(List<IQuestion<long>> questions)
        {
            return new SumQuestion(questions);
        }
    }
}