namespace ChatApplication.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeSaltToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Salt", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Salt", c => c.Binary());
        }
    }
}
