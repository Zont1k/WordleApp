namespace WordleApp.Models
{
    public class GameState
    {
        public string TargetWord { get; set; }
        public List<string> Attempts { get; set; } = new();
        public bool IsWon => Attempts.Any() && Attempts.Last() == TargetWord;
        public bool IsGameOver => Attempts.Count >= 6 || IsWon;

        public int Score { get; set; } = 0;
        public int Wins { get; set; } = 0;
        public int GamesPlayed { get; set; } = 0;
    }
}
