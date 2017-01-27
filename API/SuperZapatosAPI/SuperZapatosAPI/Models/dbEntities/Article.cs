using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SuperZapatosAPI.Models
{
    [Table("articles")]
    public class Article
    {

        [Key, Column("id")]
        public virtual int Id { get; set; }

        [StringLength(255)]
        [Column("name")]
        public virtual string Name { get; set; }

        [StringLength(255)]
        [Column("description")]
        public virtual string Description { get; set; }

        [Column("price")]
        public virtual Decimal Price { get; set; }

        [Column("total_in_shelf")]
        public virtual int TotalInShelf { get; set; }

        [Column("total_in_vault")]
        public virtual int TotalInVault { get; set; }

        [Column("store_id")]
        public int StoreId { get; set; }

        public Store Store { get; set; }
    }
}