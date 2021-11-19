namespace ChatApplication.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGroupUserType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserGroups", "GroupUserType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserGroups", "GroupUserType");
        }
    }
}
