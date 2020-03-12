using SocialXray.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SocialXray.Lib;

namespace SocialXray.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var searchResults = TwitterSearch.SearchByHashTag("salesforce", 15);

            string chartResults = "['Date', 'Salesforce']";
            var dateKeys = searchResults.Keys.ToList();
            dateKeys.Sort();
            foreach(var key in dateKeys)
            {
                if (!string.IsNullOrEmpty(chartResults))
                {
                    chartResults += ",";
                }
                chartResults += ($"['{key:d}', {searchResults[key]}]");
            }

            /*
            var keywords = new[]
            {
                new Tuple<string, int>("pepsi", 2000),
                new Tuple<string, int>("coca-cola", 1000)
            };
            */

            var model = new ReportViewModels
            {
                KeywordsPopularity = chartResults,
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
