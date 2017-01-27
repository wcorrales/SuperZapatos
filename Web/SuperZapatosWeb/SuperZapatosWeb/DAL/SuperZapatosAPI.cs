using SuperZapatosWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace SuperZapatosWeb.DAL
{
    public static class SuperZapatosAPI
    {
        #region HttpClient
        /// <summary>
        /// Access the API using Basic Authentication
        /// </summary>
        /// <returns>HttpClient</returns>
        public static HttpClient GetAPIClient() {
            string username;
            string password;

            string url = ConfigurationManager.AppSettings["APIServer"];

            username = ConfigurationManager.AppSettings["username"];
            password = ConfigurationManager.AppSettings["password"];

            HttpClient client = new HttpClient();

            string authInfo = username + ":" + password;
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authInfo);
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
        #endregion

        #region Stores
        /// <summary>
        /// Call the API to get or sent data related to stores
        /// </summary>
        /// <param name="path">Url path for the API</param>
        /// <param name="_data">Object to send to the service (Default null)</param>
        /// <returns>StoreResponse</returns>
        public static StoreResponse CallStoreAPI(string path, object _data = null)
        {
            HttpClient client = SuperZapatosAPI.GetAPIClient();
            string data = "";
            if (_data != null) {
                data = new JavaScriptSerializer().Serialize(_data);
            }

            HttpContent content = new StringContent(data);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            StoreResponse obj = new StoreResponse();
            try
            {
                HttpResponseMessage response = client.PostAsync(path, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body. Blocking!
                    // Creating Serializer
                    var serializer = new JavaScriptSerializer();
                    var dataResult = response.Content.ReadAsStringAsync().Result;

                    // Creating Json Request Object
                    obj = new JavaScriptSerializer().Deserialize<StoreResponse>(dataResult);

                }
                else
                {
                    //Read response content result into string variable
                    string strJson = response.Content.ReadAsStringAsync().Result;

                    //ViewBag.Response = response.ReasonPhrase;
                }

            }
            catch (Exception ex)
            {
                //ViewBag.Error = ex.Message;
            }
            return obj;
        }

        /// <summary>
        /// Call the API to get or sent data related to stores
        /// </summary>
        /// <param name="path">Url path for the API</param>
        /// <param name="_data">Object to send to the service (Default null)</param>
        /// <returns>StoreResponse</returns>
        public static StoreResponse GetStoreAPI(string path, string id = "")
        {
            HttpClient client = SuperZapatosAPI.GetAPIClient();
            
            StoreResponse obj = new StoreResponse();
            try
            {
                HttpResponseMessage response = client.GetAsync(path + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body. Blocking!
                    // Creating Serializer
                    var serializer = new JavaScriptSerializer();
                    var dataResult = response.Content.ReadAsStringAsync().Result;

                    // Creating Json Request Object
                    obj = new JavaScriptSerializer().Deserialize<StoreResponse>(dataResult);

                }
                else
                {
                    //Read response content result into string variable
                    string strJson = response.Content.ReadAsStringAsync().Result;

                    //ViewBag.Response = response.ReasonPhrase;
                }

            }
            catch (Exception ex)
            {
                //ViewBag.Error = ex.Message;
            }
            return obj;
        }
        
        #endregion

        #region Articles
        /// <summary>
        /// Call the API to get or sent data related to articles
        /// </summary>
        /// <param name="path">Url path for the API</param>
        /// <param name="_data">Object to send to the service (Default null)</param>
        /// <returns>ArticleResponse</returns>
        public static ArticleResponse CallArticleAPI(string path, object _data = null)
        {
            HttpClient client = SuperZapatosAPI.GetAPIClient();
            string data = "";
            if (_data != null)
            {
                data = new JavaScriptSerializer().Serialize(_data);
            }

            HttpContent content = new StringContent(data);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            ArticleResponse obj = new ArticleResponse();
            try
            {
                HttpResponseMessage response = client.PostAsync(path, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body. Blocking!
                    // Creating Serializer
                    var serializer = new JavaScriptSerializer();
                    var dataResult = response.Content.ReadAsStringAsync().Result;

                    // Creating Json Request Object
                    obj = new JavaScriptSerializer().Deserialize<ArticleResponse>(dataResult);
                }
                else
                {
                    //Read response content result into string variable
                    string strJson = response.Content.ReadAsStringAsync().Result;

                    //ViewBag.Response = response.ReasonPhrase;
                }

            }
            catch (Exception ex)
            {
                //ViewBag.Error = ex.Message;
            }
            return obj;
        }

        /// <summary>
        /// Call the API to get or sent data related to articles
        /// </summary>
        /// <param name="path">Url path for the API</param>
        /// <param name="_data">Object to send to the service (Default null)</param>
        /// <returns>ArticleResponse</returns>
        public static ArticleResponse GetArticleAPI(string path, string id = "")
        {
            HttpClient client = SuperZapatosAPI.GetAPIClient();
            
            ArticleResponse obj = new ArticleResponse();
            try
            {
                HttpResponseMessage response = client.GetAsync(path + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response body. Blocking!
                    // Creating Serializer
                    var serializer = new JavaScriptSerializer();
                    var dataResult = response.Content.ReadAsStringAsync().Result;

                    // Creating Json Request Object
                    obj = new JavaScriptSerializer().Deserialize<ArticleResponse>(dataResult);
                }
                else
                {
                    //Read response content result into string variable
                    string strJson = response.Content.ReadAsStringAsync().Result;

                    //ViewBag.Response = response.ReasonPhrase;
                }

            }
            catch (Exception ex)
            {
                //ViewBag.Error = ex.Message;
            }
            return obj;
        }

        #endregion
    }
}