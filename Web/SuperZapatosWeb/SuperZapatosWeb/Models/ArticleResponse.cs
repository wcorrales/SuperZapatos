using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperZapatosWeb.Models
{
    public class ArticleResponse
    {
        public ArticleResponse()
        {
            articles = new List<ArticleModel>();
        }

        public string status { get; set; }

        public List<ArticleModel> articles { get; set; }

        public string error_code { get; set; }

        public string error_msg { get; set; }

        public int totalElements { get; set; }
    }
}