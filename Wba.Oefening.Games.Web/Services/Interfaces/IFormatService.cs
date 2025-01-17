using Wba.Oefening.Games.Core.Entities;

namespace Wba.Oefening.Games.Web.Services.Interfaces
{
    public interface IFormatService
    {
        string FormatGameInfo(Game game);
        string FormatGameInfo(IEnumerable<Game> games);
        string FormatDeveloperInfo(Developer developer);
        string FormatDeveloperInfo(IEnumerable<Developer> developers);
    }
}
