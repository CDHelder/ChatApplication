namespace ChatApplication.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSaltAppUserProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Salt", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Salt");
        }
    }
}
