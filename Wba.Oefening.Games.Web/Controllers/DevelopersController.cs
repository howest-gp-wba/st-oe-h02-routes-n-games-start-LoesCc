using Microsoft.AspNetCore.Mvc;
using System.Text;
using Wba.Oefening.Games.Core.Entities;

namespace Wba.Oefening.Games.Web.Controllers
{
    public class DevelopersController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
    }
}
