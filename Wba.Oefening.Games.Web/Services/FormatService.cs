using Wba.Oefening.Games.Core.Entities;

namespace Wba.Oefening.Games.Web.Services
{
    public class FormatService : IFormatService
    {
        public string FormatGameInfo(Game game)
        {
            string content = $"<ul>" +
                $"<li>Id: {game?.Id ?? 0}</li>" +
                $"<li>Title:<a href='/games/{game.Id}'>{game?.Title ?? "<NoTitle>"}</a></li>" +
                $"<li>Developer: {game?.Developer?.Name ?? "<NoName>"}</li>" +
                $"<li>Rating: {game?.Rating ?? 0}</li>" +
                $"</ul";
            return content;
        }

        public string FormatGameInfo(IEnumerable<Game> games)
        {
            string content = "";
            foreach (Game game in games)
            {
                content += FormatGameInfo(game);
            }
            return content;
        }
    }
}
