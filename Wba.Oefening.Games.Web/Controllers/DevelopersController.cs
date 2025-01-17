using Microsoft.AspNetCore.Mvc;
using System.Text;
using Wba.Oefening.Games.Core.Entities;
using Wba.Oefening.Games.Core.Repositories;

namespace Wba.Oefening.Games.Web.Controllers
{
    public class DevelopersController : Controller
    {
        private readonly DeveloperRepository _developerRepository;

        public DevelopersController()
        {
            _developerRepository = new DeveloperRepository();
        }

        public IActionResult Index()
        {
            //get the developers
            IEnumerable<Developer> developers = _developerRepository.GetDevelopers();
            //pass to the Format method
            string devInfo = $"<h1>Developers page</h1>\n{FormatDeveloperInfo(developers)}";
            //and return to the client
            return Content(devInfo, "text/html");
        }

        public IActionResult ShowDeveloper(int id)
        {
            Developer developerToShow = _developerRepository.GetDevelopers()
                .FirstOrDefault(dev => dev.Id == id);
            if (developerToShow == null) return RedirectToAction("Index");

            string devInfo = FormatDeveloperInfo(developerToShow);
            return Content(devInfo, "text/html");
        }

        private string FormatDeveloperInfo(Developer developer)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div>");
            sb.AppendLine("<h3>Developer info</h3>");
            sb.AppendLine("<ul>");
            sb.AppendLine($"<li>Developer Id: {developer?.Id ?? 0}</li>");
            sb.AppendLine($"<li>Name: {developer?.Name ?? "<unknown>"}</li>");
            sb.AppendLine("</ul>");
            sb.AppendLine("</div>");
            return sb.ToString();
        }

        private string FormatDeveloperInfo(IEnumerable<Developer> developers)
        {
            string developerInfo = string.Empty;
            foreach (Developer dev in developers)
            {
                developerInfo += $"{FormatDeveloperInfo(dev)}\n";
            }
            return developerInfo;
        }
    }
}
