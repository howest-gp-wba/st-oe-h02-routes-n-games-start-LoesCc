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
        private readonly FormatService _formatService;

        public GamesController()
        {
            _gameRepository = new GameRepository();
            _formatService = new FormatService();
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
            return Content(_formatService.FormatGameInfo(game), "text/html");
        }

        public IActionResult Index()
        {
            //get the games
            var games = _gameRepository.GetGames();
            //pass to the Format method
            //and return to the client
            return Content(_formatService.FormatGameInfo(games), "text/html");
        }

        private string FormatGameInfo(Game game)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<h3>Game info</h3>");
            sb.AppendLine("<ul>");
            sb.AppendLine($"<li>Game Id: {game.Id}</li>");
            sb.AppendLine($"<li>Title: {game.Title}</li>");
            sb.AppendLine($"<li>Developer: {game.Developer.Name}</li>");
            sb.AppendLine($"<li>Rating: {game.Rating.ToString()}</li>");
            sb.AppendLine("</ul>");
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
