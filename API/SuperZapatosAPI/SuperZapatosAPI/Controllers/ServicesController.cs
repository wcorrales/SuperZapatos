using SuperZapatosAPI.Filters;
using SuperZapatosAPI.Models;
using SuperZapatosAPI.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace SuperZapatosAPI.Controllers
{
    [IdentityBasicAuthentication]
    [Authorize]
    public class ServicesController : ApiController
    {
        #region Stores

        [Route("services/stores/{id?}")]
        [HttpGet]
        public object stores(string id = "")
        {
            StoreResponse storeResponse = new StoreResponse();
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    Store storesDb = DBUtility.GetStoreById(id);

                    if (storesDb != null)
                    {
                        storeResponse.status = "true";
                        storeResponse.totalElements = 1;

                        StoreModel newStore = new StoreModel();
                        newStore.Id = storesDb.Id;
                        newStore.Name = storesDb.Name;
                        newStore.Address = storesDb.Address;
                        storeResponse.stores.Add(newStore);
                    }
                }
                else {
                    List<Store> storesDb = DBUtility.GetStores();

                    if (storesDb != null)
                    {
                        storeResponse.status = "true";
                        storeResponse.totalElements = storesDb.Count();
                        foreach (var item in storesDb)
                        {
                            StoreModel newStore = new StoreModel();
                            newStore.Id = item.Id;
                            newStore.Name = item.Name;
                            newStore.Address = item.Address;
                            storeResponse.stores.Add(newStore);
                        }
                    }
                }

            }
            catch (System.Exception ex)
            {
                storeResponse.status = "false";
                storeResponse.error_code = "500";
                storeResponse.error_msg = "Server Error";
            }
            return storeResponse;
        }

        [Route("services/createStore")]
        [HttpPost]
        public object createStore([FromBody]StoreModel model)
        {
            StoreResponse storeResponse = new StoreResponse();
            try
            {
                if (model != null)
                {
                    Store newStore = new Store();
                    newStore.Id = model.Id;
                    newStore.Name = model.Name;
                    newStore.Address = model.Address;
                    DBUtility.CreateStore(newStore);
                    storeResponse.status = "true";
                    storeResponse.totalElements = 1;
                    storeResponse.stores.Add(model);
                }
            }
            catch (System.Exception ex)
            {
                storeResponse.status = "false";
                storeResponse.error_code = "500";
                storeResponse.error_msg = "Server Error";
            }
            return storeResponse;
        }

        //Post Update store
        [Route("services/updateStore")]
        [HttpPost]
        public object updateStore([FromBody]StoreModel model)
        {
            StoreResponse storeResponse = new StoreResponse();
            try
            {
                if (model != null)
                {
                    Store newStore = new Store();
                    newStore.Id = model.Id;
                    newStore.Name = model.Name;
                    newStore.Address = model.Address;
                    DBUtility.UpdateStore(newStore);
                    storeResponse.status = "true";
                    storeResponse.totalElements = 1;
                    storeResponse.stores.Add(model);
                }
            }
            catch (System.Exception ex)
            {
                storeResponse.status = "false";
                storeResponse.error_code = "500";
                storeResponse.error_msg = "Server Error";
            }
            return storeResponse;
        }

        [Route("services/deleteStore")]
        [HttpPost]
        public object deleteStore([FromBody]IdentifierModel ident)
        {
            StoreResponse storeResponse = new StoreResponse();
            try
            {
                if (ident != null && !string.IsNullOrEmpty(ident.id))
                {
                    DBUtility.DeleteStore(ident.id);
                    storeResponse.status = "true";
                    storeResponse.totalElements = 1;
                }
            }
            catch (System.Exception ex)
            {
                storeResponse.status = "false";
                storeResponse.error_code = "500";
                storeResponse.error_msg = "Server Error";
            }
            return storeResponse;
        }
        #endregion

        #region Articles
        [Route("services/articles/{id?}")]
        [HttpGet]
        public object articles(string id = "")
        {
            ArticleResponse articleResponse = new ArticleResponse();
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    Article articlesDb = DBUtility.GetArticleById(id);

                    if (articlesDb != null)
                    {
                        articleResponse.status = "true";
                        articleResponse.totalElements = 1;

                        ArticleModel newArticle = new ArticleModel();
                        newArticle.Id = articlesDb.Id;
                        newArticle.Name = articlesDb.Name;
                        newArticle.Description = articlesDb.Description;
                        newArticle.Price = articlesDb.Price;
                        newArticle.TotalInShelf = articlesDb.TotalInShelf;
                        newArticle.TotalInVault = articlesDb.TotalInVault;
                        newArticle.StoreId = articlesDb.StoreId;
                        newArticle.Store = articlesDb.Store;
                        articleResponse.articles.Add(newArticle);
                    }
                }
                else
                {
                    List<Article> articlesDb = DBUtility.GetArticles();

                    if (articlesDb != null)
                    {
                        articleResponse.status = "true";
                        articleResponse.totalElements = articlesDb.Count();
                        foreach (var item in articlesDb)
                        {
                            ArticleModel newArticle = new ArticleModel();
                            newArticle.Id = item.Id;
                            newArticle.Name = item.Name;
                            newArticle.Description = item.Description;
                            newArticle.Price = item.Price;
                            newArticle.TotalInShelf = item.TotalInShelf;
                            newArticle.TotalInVault = item.TotalInVault;
                            newArticle.StoreId = item.StoreId;
                            newArticle.Store = item.Store;
                            articleResponse.articles.Add(newArticle);
                        }
                    }
                }

            }
            catch (System.Exception ex)
            {
                articleResponse.status = "false";
                articleResponse.error_code = "500";
                articleResponse.error_msg = "Server Error";
            }
            return articleResponse;
        }

        [Route("services/articles/stores/{id}")]
        [HttpGet]
        public object articlesByStore(string id)
        {
            ArticleResponse articleResponse = new ArticleResponse();
            try
            {
                int idInt = 0;

                if (int.TryParse(id, out idInt))
                {
                    if (DBUtility.ExistStore(id))
                    {
                        List<Article> articlesDb = DBUtility.GetArticlesByStore(id);

                        if (articlesDb != null)
                        {
                            articleResponse.status = "true";
                            articleResponse.totalElements = articlesDb.Count();
                            foreach (var item in articlesDb)
                            {
                                ArticleModel newArticle = new ArticleModel();
                                newArticle.Id = item.Id;
                                newArticle.Name = item.Name;
                                newArticle.Description = item.Description;
                                newArticle.Price = item.Price;
                                newArticle.TotalInShelf = item.TotalInShelf;
                                newArticle.TotalInVault = item.TotalInVault;
                                newArticle.StoreId = item.StoreId;
                                newArticle.Store = item.Store;
                                articleResponse.articles.Add(newArticle);
                            }
                        }
                    }
                    else
                    {
                        articleResponse.status = "false";
                        articleResponse.error_code = "404";
                        articleResponse.error_msg = "Record not Found";
                    }
                }
                else {
                    articleResponse.status = "false";
                    articleResponse.error_code = "400";
                    articleResponse.error_msg = "Bad Request";
                }

            }
            catch (System.Exception ex)
            {
                articleResponse.status = "false";
                articleResponse.error_code = "500";
                articleResponse.error_msg = "Server Error";
            }
            return articleResponse;
        }

        [Route("services/createArticle")]
        [HttpPost]
        public object createArticle([FromBody]ArticleModel model)
        {
            ArticleResponse articleResponse = new ArticleResponse();
            try
            {
                if (model != null)
                {
                    Article newArticle = new Article();
                    newArticle.Id = model.Id;
                    newArticle.Name = model.Name;
                    newArticle.Description = model.Description;
                    newArticle.Price = model.Price;
                    newArticle.TotalInShelf = model.TotalInShelf;
                    newArticle.TotalInVault = model.TotalInVault;
                    newArticle.StoreId = model.StoreId;
                    DBUtility.CreateArticle(newArticle);
                    articleResponse.status = "true";
                    articleResponse.totalElements = 1;
                    articleResponse.articles.Add(model);
                }
            }
            catch (System.Exception ex)
            {
                articleResponse.status = "false";
                articleResponse.error_code = "500";
                articleResponse.error_msg = "Server Error";
            }
            return articleResponse;
        }

        //Post Update Article
        [Route("services/updateArticle")]
        [HttpPost]
        public object updateArticle([FromBody]ArticleModel model)
        {
            ArticleResponse articleResponse = new ArticleResponse();
            try
            {
                if (model != null)
                {
                    Article newArticle = new Article();
                    newArticle.Id = model.Id;
                    newArticle.Name = model.Name;
                    newArticle.Description = model.Description;
                    newArticle.Price = model.Price;
                    newArticle.TotalInShelf = model.TotalInShelf;
                    newArticle.TotalInVault = model.TotalInVault;
                    newArticle.StoreId = model.StoreId;
                    DBUtility.UpdateArticle(newArticle);
                    articleResponse.status = "true";
                    articleResponse.totalElements = 1;
                    articleResponse.articles.Add(model);
                }
            }
            catch (System.Exception ex)
            {
                articleResponse.status = "false";
                articleResponse.error_code = "500";
                articleResponse.error_msg = "Server Error";
            }
            return articleResponse;
        }

        [Route("services/deleteArticle")]
        [HttpPost]
        public object deleteArticle([FromBody]IdentifierModel ident)
        {
            ArticleResponse articleResponse = new ArticleResponse();
            try
            {
                if (ident != null && !string.IsNullOrEmpty(ident.id))
                {
                    DBUtility.DeleteArticle(ident.id);
                    articleResponse.status = "true";
                    articleResponse.totalElements = 1;
                }
            }
            catch (System.Exception ex)
            {
                articleResponse.status = "false";
                articleResponse.error_code = "500";
                articleResponse.error_msg = "Server Error";
            }
            return articleResponse;
        }
        #endregion

    }
}
