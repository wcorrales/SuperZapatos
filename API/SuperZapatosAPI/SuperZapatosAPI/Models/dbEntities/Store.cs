using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SuperZapatosAPI.Models
{
    [Table("stores")]
    public class Store
    {
        [Key, Column("id")]
        public virtual int Id { get; set; }

        [StringLength(255)]
        [Column("name")]
        public virtual string Name { get; set; }

        [StringLength(255)]
        [Column("address")]
        public virtual string Address { get; set; }

    }
}