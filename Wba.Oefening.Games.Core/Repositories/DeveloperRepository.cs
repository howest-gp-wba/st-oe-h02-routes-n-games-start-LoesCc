using System.Collections.Generic;
using Wba.Oefening.Games.Core.Entities;

namespace Wba.Oefening.Games.Core.Repositories
{
    public class DeveloperRepository
    {
        public IEnumerable<Developer> GetDevelopers()
        {
            return new List<Developer>
            {
                new Developer{ Id = 1, Name = "Ubisoft" },
                new Developer{ Id = 2, Name = "EA" },
                new Developer{ Id = 3, Name = "Bethesda" }
            };
        }
    }
}
