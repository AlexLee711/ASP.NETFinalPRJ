//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace prjFinalProject.Models
{
    using System;
    using System.Configuration;
    using System.Data.Common;
    using System.Data.Entity;
    using System.Data.Entity.Core.EntityClient;
    using System.Data.Entity.Infrastructure;
    
    public partial class dbArtsCenterEntities : DbContext
    {
        public dbArtsCenterEntities()
            : base("name=dbArtsCenterEntities")
        {
            var originalConnectionString = ConfigurationManager.ConnectionStrings["dbArtsCenterEntities"].ConnectionString;
            var entityBuilder = new EntityConnectionStringBuilder(originalConnectionString);
            var factory = DbProviderFactories.GetFactory(entityBuilder.Provider);
            var providerBuilder = factory.CreateConnectionStringBuilder();

            providerBuilder.ConnectionString = entityBuilder.ProviderConnectionString;
            providerBuilder.Add("Password", "yzuim1092netdbB");
            entityBuilder.ProviderConnectionString = providerBuilder.ToString();
            this.Database.Connection.ConnectionString = entityBuilder.ProviderConnectionString;

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TableCenters1081753> TableCenters1081753 { get; set; }
        public virtual DbSet<TableMembers1081753> TableMembers1081753 { get; set; }
        public virtual DbSet<TableWishLists1081753> TableWishLists1081753 { get; set; }
    }
}
