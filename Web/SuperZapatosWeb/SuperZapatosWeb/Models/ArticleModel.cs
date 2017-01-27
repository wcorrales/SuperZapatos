using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperZapatosWeb.Models
{
    public class ArticleModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Decimal Price { get; set; }

        [DisplayName("Total In Shelf")]
        public int TotalInShelf { get; set; }

        [DisplayName("Total In Vault")]
        public int TotalInVault { get; set; }

        [DisplayName("Store")]
        public int StoreId { get; set; }

        public StoreModel Store { get; set; }
    }
}