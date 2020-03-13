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
            //var searchResults = TwitterSearch.SearchByHashTag("salesforce", 15);

            //string chartResults = "['Date', 'Salesforce']";
            //var dateKeys = searchResults.Keys.ToList();
            //dateKeys.Sort();
            //foreach (var key in dateKeys)
            //{
            //    if (!string.IsNullOrEmpty(chartResults))
            //    {
            //        chartResults += ",";
            //    }
            //    chartResults += ($"['{key:d}', {searchResults[key]}]");
            //}

            ///*
            //var keywords = new[]
            //{
            //    new Tuple<string, int>("pepsi", 2000),
            //    new Tuple<string, int>("coca-cola", 1000)
            //};
            //*/

            var model = new ReportViewModels
            {
                KeywordsPopularity = ""
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Report(string twit_keywor1, string twit_keywor2)
        {
            Dictionary<DateTime, int>[] searchResults = GetSearchResults(twit_keywor1, twit_keywor2);
            var model = new ReportViewModels();
            model.KeywordsPopularity = GetDataForLineChart(searchResults[0], searchResults[1],twit_keywor1, twit_keywor2);
            model.KeywordsPopularityLineChart = GetDataForColumnCharts(searchResults[0], searchResults[1], twit_keywor1, twit_keywor2);
            model.Keyword1 = twit_keywor1;
            model.Keyword2 = twit_keywor2;
            return View("Index", model);
        }

        private Dictionary<DateTime, int>[] GetSearchResults(string twit_keywor1, string twit_keywor2)
        {
            var keyword1 = TwitterSearch.SearchByHashTag(twit_keywor1, 15);
            var keyword2 = TwitterSearch.SearchByHashTag(twit_keywor2, 15);
            return new Dictionary<DateTime, int>[] { keyword1, keyword2 };
        }

        private string GetDataForLineChart(Dictionary<DateTime, int> keyword1, Dictionary<DateTime, int> keyword2, string twit_keywor1, string twit_keywor2)
        {
            string chartResults = $"['Date', '{twit_keywor1}', '{twit_keywor2}']";
            var dateKeys1 = keyword1.Keys.ToList();

            dateKeys1.Sort();

            foreach (var key in dateKeys1)
            {
                if (!string.IsNullOrEmpty(chartResults))
                {
                    chartResults += ",";
                }
                chartResults += ($"['{key:d}', {keyword1[key]}, {keyword2[key]}]");
            }

            /*
            var keywords = new[]
            {
                new Tuple<string, int>("pepsi", 2000),
                new Tuple<string, int>("coca-cola", 1000)
            };
            */

            //var model = new ReportViewModels
            //{
            //    KeywordsPopularity = chartResults,
            //};
            return chartResults;
        }

        private string GetDataForColumnCharts(Dictionary<DateTime, int> keyword1, Dictionary<DateTime, int> keyword2, string twit_keywor1, string twit_keywor2)
        {
            string chartResults = $"['Date', '{twit_keywor1}', '{twit_keywor2}']";
            var dateKeys1 = keyword1.Keys.ToList();

            dateKeys1.Sort();

            foreach (var key in dateKeys1)
            {
                if (!string.IsNullOrEmpty(chartResults))
                {
                    chartResults += ",";
                }
                //chartResults += ("[{v: " + $"'{key:d}'" + ", f: " + $"'1000'" + "}," + $"{keyword1[key]}, {keyword2[key]}]");
                chartResults += $"['{key:d}', {keyword1[key]}, {keyword2[key]}]";
            }
            return chartResults;
        }
    }
}
