using SuperZapatosAPI.dbContext;
using SuperZapatosAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SuperZapatosAPI.Utility
{
    public class DBUtility
    {
        #region Articles
        public static List<Article> GetArticles()
        {
            try
            {
                List<Article> articles = null;
                using (SuperZapatosDbContext dbContext = new SuperZapatosDbContext("SuperZapatosDbContext"))
                {
                    articles = (from result in dbContext.Articles
                                select result).ToList<Article>();
                    foreach (var article in articles)
                    {
                        Store store = (from st in dbContext.Stores
                                       where st.Id.Equals(article.StoreId)
                                       select st).FirstOrDefault();
                        article.Store = store;
                    }
                };

                return articles;
            }
            catch (Exception ex)
            {
                string sMsg = string.Format("SuperZapatos.GetArticles");
                throw new Exception(sMsg, ex);
            }
        }

        public static Article GetArticleById(string id)
        {
            try
            {
                Article article = null;
                int idInt = 0;
                if (int.TryParse(id, out idInt))
                {
                    using (SuperZapatosDbContext dbContext = new SuperZapatosDbContext("SuperZapatosDbContext"))
                    {
                        article = (from result in dbContext.Articles
                                   where result.Id.Equals(idInt)
                                   select result).FirstOrDefault();
                    };
                }

                return article;
            }
            catch (Exception ex)
            {
                string sMsg = string.Format("SuperZapatos.GetStoreById: Id={0}", id);
                throw new Exception(sMsg, ex);
            }
        }

        public static List<Article> GetArticlesByStore(string storeId)
        {
            try
            {
                List<Article> articles = null;
                 int idInt = 0;
                 if (int.TryParse(storeId, out idInt))
                 {
                     
                     using (SuperZapatosDbContext dbContext = new SuperZapatosDbContext("SuperZapatosDbContext"))
                     {
                         articles = (from result in dbContext.Articles
                                     where result.StoreId.Equals(idInt)
                                     select result).ToList<Article>();
                         foreach (var article in articles)
                         {
                             Store store = (from st in dbContext.Stores
                                            where st.Id.Equals(article.StoreId)
                                            select st).FirstOrDefault();
                             article.Store = store;
                         }
                     };
                 }
                return articles;
            }
            catch (Exception ex)
            {
                string sMsg = string.Format("SuperZapatos.GetArticlesByStore: Id={0}", storeId);
                throw new Exception(sMsg, ex);
            }
        }

        public static void CreateArticle(Article article)
        {
            try
            {
                using (SuperZapatosDbContext dbContext = new SuperZapatosDbContext("SuperZapatosDbContext"))
                {
                    dbContext.Articles.Add(article);
                    dbContext.SaveChanges();
                };
            }
            catch (Exception ex)
            {
                string sMsg = string.Format("SuperZapatos.CreateStore");
                throw new Exception(sMsg, ex);
            }
        }

        public static void UpdateArticle(Article article)
        {
            try
            {
                using (SuperZapatosDbContext dbContext = new SuperZapatosDbContext("SuperZapatosDbContext"))
                {
                    dbContext.Entry(article).State = EntityState.Modified;
                    dbContext.SaveChanges();
                };
            }
            catch (Exception ex)
            {
                string sMsg = string.Format("SuperZapatos.UpdateStore");
                throw new Exception(sMsg, ex);
            }
        }

        public static void DeleteArticle(string id)
        {
            try
            {
                int idInt = 0;
                if (int.TryParse(id, out idInt))
                {
                    using (SuperZapatosDbContext dbContext = new SuperZapatosDbContext("SuperZapatosDbContext"))
                    {
                        Article articlemodel = dbContext.Articles.Find(idInt);
                        dbContext.Articles.Remove(articlemodel);
                        dbContext.SaveChanges();
                    };
                }
            }
            catch (Exception ex)
            {
                string sMsg = string.Format("SuperZapatos.DeleteStore");
                throw new Exception(sMsg, ex);
            }
        }
        #endregion

        #region Stores
        public static List<Store> GetStores()
        {
            try
            {
                List<Store> stores = null;
                using (SuperZapatosDbContext dbContext = new SuperZapatosDbContext("SuperZapatosDbContext"))
                {
                    stores = (from result in dbContext.Stores
                              select result).ToList<Store>();
                };

                return stores;
            }
            catch (Exception ex)
            {
                string sMsg = string.Format("SuperZapatos.GetStores");
                throw new Exception(sMsg, ex);
            }
        }

        public static Store GetStoreById(string id)
        {
            try
            {
                Store store = null;
                int idInt = 0;
                if (int.TryParse(id, out idInt))
                {
                    using (SuperZapatosDbContext dbContext = new SuperZapatosDbContext("SuperZapatosDbContext"))
                    {
                        store = (from result in dbContext.Stores
                                 where result.Id.Equals(idInt)
                                 select result).FirstOrDefault();
                    };
                }

                return store;
            }
            catch (Exception ex)
            {
                string sMsg = string.Format("SuperZapatos.GetStoreById: Id={0}", id);
                throw new Exception(sMsg, ex);
            }
        }

        public static bool ExistStore(string id)
        {
            try
            {
                Store store = null;
                int idInt = 0;
                if (int.TryParse(id, out idInt))
                {
                    using (SuperZapatosDbContext dbContext = new SuperZapatosDbContext("SuperZapatosDbContext"))
                    {
                        store = (from result in dbContext.Stores
                                 where result.Id.Equals(idInt)
                                 select result).FirstOrDefault();
                    };
                }

                return store!=null;
            }
            catch (Exception ex)
            {
                string sMsg = string.Format("SuperZapatos.GetStoreById: Id={0}", id);
                throw new Exception(sMsg, ex);
            }
        }

        public static void CreateStore(Store store)
        {
            try
            {
                using (SuperZapatosDbContext dbContext = new SuperZapatosDbContext("SuperZapatosDbContext"))
                {
                    dbContext.Stores.Add(store);
                    dbContext.SaveChanges();
                };
            }
            catch (Exception ex)
            {
                string sMsg = string.Format("SuperZapatos.CreateStore");
                throw new Exception(sMsg, ex);
            }
        }

        public static void UpdateStore(Store store) { 
            try
            {
                using (SuperZapatosDbContext dbContext = new SuperZapatosDbContext("SuperZapatosDbContext"))
                {
                    dbContext.Entry(store).State = EntityState.Modified;
                    dbContext.SaveChanges();
                };
            }
            catch (Exception ex)
            {
                string sMsg = string.Format("SuperZapatos.UpdateStore");
                throw new Exception(sMsg, ex);
            }
        }

        public static void DeleteStore(string id)
        {
            try
            {
                 int idInt = 0;
                 if (int.TryParse(id, out idInt))
                 {
                     using (SuperZapatosDbContext dbContext = new SuperZapatosDbContext("SuperZapatosDbContext"))
                     {
                         Store storemodel = dbContext.Stores.Find(idInt);
                         dbContext.Stores.Remove(storemodel);
                         dbContext.SaveChanges();
                     };
                 }
            }
            catch (Exception ex)
            {
                string sMsg = string.Format("SuperZapatos.DeleteStore");
                throw new Exception(sMsg, ex);
            }
        }
        #endregion

    }
}