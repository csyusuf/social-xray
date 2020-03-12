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
                new SelectListItem { Value = "2000", Text = "pepsi" },
                new SelectListItem { Value = "100", Text = "coca-cola" },
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
