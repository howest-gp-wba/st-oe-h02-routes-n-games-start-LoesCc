using Microsoft.AspNetCore.Mvc;
using System.Text;
using Wba.Oefening.Games.Core.Entities;
using Wba.Oefening.Games.Core.Repositories;
using Wba.Oefening.Games.Web.Services;

namespace Wba.Oefening.Games.Web.Controllers
{
    public class GamesController : Controller
    {
        private readonly GameRepository _gameRepository;

        public GamesController()
        {
            _gameRepository = new GameRepository();
        }

        /**
         * show the info of one game
         */
        public IActionResult ShowGame(int id)
        {
            //get the game using the id(FirstOrDefault)
            var game = _gameRepository
                .GetGames()
                .FirstOrDefault(g => g.Id == id);
            //check if null
            if (game == null)
            {
                return NotFound();
            }
            //return content => FormatGameInfo(Game)
            var title = game.Title;
            return Content("_formatService.FormatGameInfo(game)", "text/html");
        }

        public IActionResult Index()
        {
            //get the games
            IEnumerable<Game> games = _gameRepository.GetGames();
            //pass to the Format method
            string gameInfo = $"<h1>Games page</h1>\n{FormatGameInfo(games)}";
            //and return to the client
            return Content(gameInfo, "text/html");
        }

        private string FormatGameInfo(Game game)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div>");
            sb.AppendLine("<h3>Game info</h3>");
            sb.AppendLine("<ul>");
            sb.AppendLine($"<li>Game Id: {game?.Id ?? 0}</li>");
            sb.AppendLine($"<li>Title: {game?.Title ?? "<unknown>"}</li>");
            sb.AppendLine($"<li>Developer: {game?.Developer?.Name ?? "<unknown>"}</li>");
            sb.AppendLine($"<li>Rating: {game?.Rating ?? 0}</li>");
            sb.AppendLine("</ul>");
            sb.AppendLine("</div>");
            return sb.ToString();
        }

        private string FormatGameInfo(IEnumerable<Game> games)
        {
            string gameInfo = string.Empty;
            foreach (Game game in games)
            {
                gameInfo += $"{FormatGameInfo(game)}\n";
            }
            return gameInfo;
        }
    }
}
