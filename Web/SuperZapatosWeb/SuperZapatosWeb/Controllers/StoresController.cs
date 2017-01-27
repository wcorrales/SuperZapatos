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
    public class StoresController : Controller
    {
        // GET: /Stores/
        public ActionResult Index()
        {
            StoreResponse response = SuperZapatosAPI.GetStoreAPI("services/stores/");

            return View(response.stores);
        }

        // GET: /Stores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Stores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,Address")] StoreModel storemodel)
        {
            if (ModelState.IsValid)
            {
                StoreResponse response = SuperZapatosAPI.CallStoreAPI("services/createStore", storemodel);
                
                return RedirectToAction("Index");
            }

            return View(storemodel);
        }

        // GET: /Stores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            StoreResponse response = SuperZapatosAPI.GetStoreAPI("services/stores/", id.ToString());

            return View(response.stores[0]);
        }

        // POST: /Stores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,Address")] StoreModel storemodel)
        {
            if (ModelState.IsValid)
            {
                StoreResponse response = SuperZapatosAPI.CallStoreAPI("services/updateStore", storemodel);

                return RedirectToAction("Index");
            }
            return View(storemodel);
        }

        // GET: /Stores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            StoreResponse response = SuperZapatosAPI.GetStoreAPI("services/stores/", id.ToString());

            return View(response.stores[0]);
        }

        // POST: /Stores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IdentifierModel ident = new IdentifierModel();
            ident.id = id.ToString();
            StoreResponse response = SuperZapatosAPI.CallStoreAPI("services/deleteStore", ident);

            return RedirectToAction("Index");
        }

    }
}
