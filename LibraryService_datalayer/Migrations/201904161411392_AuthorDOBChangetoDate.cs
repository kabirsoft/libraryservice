namespace LibraryService_datalayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuthorDOBChangetoDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authors", "DOB", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Authors", "DOB", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}
