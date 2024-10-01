using Wba.Oefening.Games.Core.Entities;

namespace Wba.Oefening.Games.Web.Services
{
    public interface IFormatService
    {
        string FormatGameInfo(Game game);
        string FormatGameInfo(IEnumerable<Game> games);
    }
}
