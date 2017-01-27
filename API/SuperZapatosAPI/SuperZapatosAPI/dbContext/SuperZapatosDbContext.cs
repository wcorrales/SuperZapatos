using SuperZapatosAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SuperZapatosAPI.dbContext
{
    public class SuperZapatosDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Store> Stores { get; set; }

        #region Constructors
        public SuperZapatosDbContext(string nameOrConnectionString, bool lazyLoading = false)
            : base(nameOrConnectionString)
        {
            Initialize(lazyLoading);
        }

        public SuperZapatosDbContext(bool lazyLoading = false)
            : base()
        {
            Initialize(lazyLoading);
        }

        public SuperZapatosDbContext(DbConnection existingConnection, bool lazyLoading = false)
            : base(existingConnection, true)
        {
            Initialize(lazyLoading);
        }

        public SuperZapatosDbContext(DbConnection existingConnection, DbTransaction currentTransaction, bool lazyLoading = false)
            : base(existingConnection, false)
        {
            if (currentTransaction != null)
                this.Database.UseTransaction(currentTransaction);
        }
        #endregion Constructors

        #region Private Methods
        private void Initialize(bool lazyLoading = false)
        {
            Database.SetInitializer<SuperZapatosDbContext>(null);
            Configuration.LazyLoadingEnabled = lazyLoading;
        }
        #endregion Private Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);

        }
    }
}