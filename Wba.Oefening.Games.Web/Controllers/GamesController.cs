using Microsoft.AspNetCore.Mvc;
using System.Text;
using Wba.Oefening.Games.Core.Entities;
using Wba.Oefening.Games.Core.Repositories;
using Wba.Oefening.Games.Web.Services;
using Wba.Oefening.Games.Web.Services.Interfaces;

namespace Wba.Oefening.Games.Web.Controllers
{
    public class GamesController : Controller
    {
        private readonly GameRepository _gameRepository;
        private readonly IFormatService _formatService;

        public GamesController(IFormatService formatService)
        {            
            _formatService = formatService;
            _gameRepository = new GameRepository();
        }

        public IActionResult Index()
        {
            //get the games
            IEnumerable<Game> games = _gameRepository.GetGames();
            //pass to the Format method
            string gameInfo = $"<h1>Games page</h1>\n{_formatService.FormatGameInfo(games)}";
            //and return to the client
            return Content(gameInfo, "text/html");
        }

        public IActionResult ShowGame(int id)
        {        
            Game gameToShow = _gameRepository.GetGames()
                .FirstOrDefault(game => game.Id == id);
            if (gameToShow == null) return RedirectToAction("Index");

            string gameInfo = _formatService.FormatGameInfo(gameToShow);
            return Content(gameInfo, "text/html");
        }
    }
}
