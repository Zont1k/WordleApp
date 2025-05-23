using System.Collections.Concurrent;

namespace WordleApp.Models
{
    public static class GameStorage
    {
        private static ConcurrentDictionary<string, GameState> Games = new();

        public static GameState GetGame(string userId)
        {
            if (!Games.ContainsKey(userId))
                Games[userId] = new GameState { TargetWord = WordProvider.GetRandomWord() };

            return Games[userId];
        }

        public static void UpdateGame(string userId, GameState game) => Games[userId] = game;
        public static void ResetGame(string userId) => Games.TryRemove(userId, out _);
    }
}
