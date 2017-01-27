using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SuperZapatosWeb.Models;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;
using System.Web.Script.Serialization;
using SuperZapatosWeb.DAL;

namespace SuperZapatosWeb.Controllers
{
    public class ArticlesController : Controller
    {
        //private SuperZapatosWebContext db = new SuperZapatosWebContext();

        // GET: /Articles/
        public ActionResult Index()
        {
            ArticleResponse response = SuperZapatosAPI.GetArticleAPI("services/articles/");

            return View(response.articles);
        }

        // GET: /Articles/Create
        public ActionResult Create()
        {
            //Get Stores to fill the dropdown
            StoreResponse responseStore = SuperZapatosAPI.GetStoreAPI("services/stores/");
            
            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach (var item in responseStore.stores)
            {
                SelectListItem newItem = new SelectListItem(){
                    Text = item.Name,
                    Value=item.Id.ToString()
                };
                listItems.Add(newItem);
                
            }
            ViewBag.Stores = listItems;

            return View();
        }

        // POST: /Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,Description,Price,TotalInShelf,TotalInVault,StoreId")] ArticleModel articlemodel)
        {
            if (ModelState.IsValid)
            {
                ArticleResponse response = SuperZapatosAPI.CallArticleAPI("services/createArticle", articlemodel);

                return RedirectToAction("Index");
            }

            return View(articlemodel);
        }

        // GET: /Articles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ArticleResponse response = SuperZapatosAPI.GetArticleAPI("services/articles/", id.ToString());

            //Get Stores to fill the dropdown
            StoreResponse responseStore = SuperZapatosAPI.GetStoreAPI("services/stores/");

            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach (var item in responseStore.stores)
            {
                SelectListItem newItem = new SelectListItem()
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                };
                listItems.Add(newItem);

            }
            ViewBag.Stores = listItems;

            return View(response.articles[0]);
        }

        // POST: /Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,Description,Price,TotalInShelf,TotalInVault,StoreId")] ArticleModel articlemodel)
        {
            if (ModelState.IsValid)
            {
                ArticleResponse response = SuperZapatosAPI.CallArticleAPI("services/updateArticle", articlemodel);

                return RedirectToAction("Index");
            }
            return View(articlemodel);
        }

        // GET: /Articles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ArticleResponse response = SuperZapatosAPI.GetArticleAPI("services/articles/", id.ToString());

            return View(response.articles[0]);
        }

        // POST: /Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IdentifierModel ident = new IdentifierModel();
            ident.id = id.ToString();
            ArticleResponse response = SuperZapatosAPI.CallArticleAPI("services/deleteArticle", ident);

            return RedirectToAction("Index");
        }

    }
}
