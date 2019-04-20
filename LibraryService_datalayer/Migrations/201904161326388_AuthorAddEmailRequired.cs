namespace LibraryService_datalayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuthorAddEmailRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authors", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Authors", "Email", c => c.String());
        }
    }
}
