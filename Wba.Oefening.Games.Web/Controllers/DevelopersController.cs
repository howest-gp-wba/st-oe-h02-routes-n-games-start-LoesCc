using Microsoft.AspNetCore.Mvc;
using System.Text;
using Wba.Oefening.Games.Core.Entities;
using Wba.Oefening.Games.Core.Repositories;
using Wba.Oefening.Games.Web.Services.Interfaces;

namespace Wba.Oefening.Games.Web.Controllers
{
    public class DevelopersController : Controller
    {
        private readonly DeveloperRepository _developerRepository;
        private readonly IFormatService _formatService;

        public DevelopersController(IFormatService formatService)
        {
            _formatService = formatService;
            _developerRepository = new DeveloperRepository();
        }

        public IActionResult Index()
        {
            //get the developers
            IEnumerable<Developer> developers = _developerRepository.GetDevelopers();
            //pass to the Format method
            string devInfo = $"<h1>Developers page</h1>\n{_formatService.FormatDeveloperInfo(developers)}";
            //and return to the client
            return Content(devInfo, "text/html");
        }

        public IActionResult ShowDeveloper(int id)
        {
            Developer developerToShow = _developerRepository.GetDevelopers()
                .FirstOrDefault(dev => dev.Id == id);
            if (developerToShow == null) return RedirectToAction("Index");

            string devInfo = _formatService.FormatDeveloperInfo(developerToShow);
            return Content(devInfo, "text/html");
        }
    }
}
