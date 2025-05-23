using Microsoft.AspNetCore.Mvc;
using WordleApp.Models;

namespace WordleApp.Controllers
{
    public class HomeController : Controller
    {
        private string GetUserId()
        {
            if (!Request.Cookies.ContainsKey("UserId"))
            {
                var id = Guid.NewGuid().ToString();
                Response.Cookies.Append("UserId", id);
                return id;
            }
            return Request.Cookies["UserId"];
        }

        public IActionResult Index()
        {
            var userId = GetUserId();
            var game = GameStorage.GetGame(userId);
            return View(game);
        }

        [HttpPost]
        public IActionResult Guess(string word)
        {
            var userId = GetUserId();
            var game = GameStorage.GetGame(userId);

            if (!game.IsGameOver && word.Length == 5)
            {
                game.Attempts.Add(word);

                if (game.IsWon)
                {
                    game.Score += 10;
                    game.Wins++;
                }
                else if (game.IsGameOver)
                {
                    game.Score -= 2;
                }

                game.GamesPlayed++;
            }

            GameStorage.UpdateGame(userId, game);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Restart()
        {
            var userId = GetUserId();
            GameStorage.ResetGame(userId);
            return RedirectToAction("Index");
        }
    }
}
