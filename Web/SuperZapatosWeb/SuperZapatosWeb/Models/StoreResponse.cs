using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuperZapatosWeb.Models
{
    public class StoreResponse
    {
        public StoreResponse()
        {
            stores = new List<StoreModel>();
        }

        public string status { get; set; }

        public List<StoreModel> stores { get; set; }

        public string error_code { get; set; }

        public string error_msg { get; set; }

        public int totalElements { get; set; }
    }
}