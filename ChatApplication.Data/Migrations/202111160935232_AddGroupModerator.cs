namespace ChatApplication.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGroupModerator : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GroupChats", "Groupmoderator_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.GroupChats", "Groupmoderator_Id");
            AddForeignKey("dbo.GroupChats", "Groupmoderator_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroupChats", "Groupmoderator_Id", "dbo.AspNetUsers");
            DropIndex("dbo.GroupChats", new[] { "Groupmoderator_Id" });
            DropColumn("dbo.GroupChats", "Groupmoderator_Id");
        }
    }
}
