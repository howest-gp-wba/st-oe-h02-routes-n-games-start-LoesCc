using System.Collections.Generic;
using System.Linq;
using Wba.Oefening.Games.Core.Entities;

namespace Wba.Oefening.Games.Core.Repositories
{
    public class GameRepository
    {
        public IEnumerable<Game> GetGames()
        {
            DeveloperRepository developerRepository = new DeveloperRepository();
            return new List<Game>
            {
                new Game
                {
                    Id = 1,
                    Title = "Wolfenstein Colossus",
                    Developer =
                        developerRepository.GetDevelopers().
                            First(dev => dev.Id == 1)
                },
                new Game
                {
                    Id = 2,
                    Title ="FIFA 2021",
                    Developer =
                        developerRepository.GetDevelopers().
                            First(dev => dev.Id == 2)
                },
                new Game
                {
                    Id = 3,
                    Title ="Elder Scrolls V: Skyrim",
                    Developer =
                        developerRepository.GetDevelopers().
                            First(dev => dev.Id == 3)
                }
            };
        }
    }
}
