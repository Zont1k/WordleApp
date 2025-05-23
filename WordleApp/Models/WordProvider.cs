namespace WordleApp.Models
{
    public static class WordProvider
    {
        private static readonly List<string> Words = new()
        {
            "жираф", "птица", "камин", "поезд", "мирок", "арбуз"
        };

        public static string GetRandomWord()
        {
            var rnd = new Random();
            return Words[rnd.Next(Words.Count)];
        }
    }
}
