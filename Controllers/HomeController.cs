using SocialXray.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SocialXray.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var keywords = new[]
            {
                new Tuple<string, int>("pepsi", 2000),
                new Tuple<string, int>("coca-cola", 1000)
            };

            var model = new ReportViewModels
            {
                KeywordsPopularity = keywords,
                Test = "I got the idea"
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult Report()
        {
            return null;
        }
    }
}
