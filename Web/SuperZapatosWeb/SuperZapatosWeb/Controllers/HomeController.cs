using SuperZapatosWeb.DAL;
using SuperZapatosWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace SuperZapatosWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            StoreResponse responseStore = SuperZapatosAPI.GetStoreAPI("services/stores/");
            ArticleResponse responseArticle = SuperZapatosAPI.GetArticleAPI("services/articles/");

            ViewBag.Stores = responseStore.stores;
            ViewBag.Articles = responseArticle.articles;
            return View();
        }

        public ActionResult ArticlesByStore(string id)
        {
            IdentifierModel ident = new IdentifierModel();
            ident.id = id.ToString();
            ArticleResponse responseArticle = SuperZapatosAPI.GetArticleAPI("services/articles/stores/", id);
            if (responseArticle.status != null && responseArticle.status.Equals("false"))
            {
                ViewBag.Response = responseArticle;
            }
            return View(responseArticle.articles);
        }
    }
}