using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialXray.Models
{
    public class ReportViewModels
    {
        [Required]
        [Display(Name = "First Keyword")]
        public string Keyword1 { get; set; }

        [Display(Name = "Second Keyword")]
        public string Keyword2 { get; set; }

        public string Test { get; set; }

        public string KeywordsPopularity { get; set; }
        public string KeywordsPopularityLineChart { get; set; }
    }
}