using System.Text;
using Wba.Oefening.Games.Core.Entities;
using Wba.Oefening.Games.Web.Services.Interfaces;

namespace Wba.Oefening.Games.Web.Services
{
    public class FormatService : IFormatService
    {
        public string FormatGameInfo(Game game)
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

        public string FormatGameInfo(IEnumerable<Game> games)
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
