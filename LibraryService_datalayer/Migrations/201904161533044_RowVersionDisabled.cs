namespace LibraryService_datalayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RowVersionDisabled : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Books", "RowVersion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
    }
}
