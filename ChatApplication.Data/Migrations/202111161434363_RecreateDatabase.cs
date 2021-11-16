namespace ChatApplication.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecreateDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "GroupChat_Id", "dbo.GroupChats");
            DropForeignKey("dbo.GroupChats", "Groupmoderator_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.PrivateChats", "UserOne_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.PrivateChats", "UserTwo_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUsers", new[] { "GroupChat_Id" });
            DropIndex("dbo.GroupChats", new[] { "Groupmoderator_Id" });
            DropIndex("dbo.PrivateChats", new[] { "UserOne_Id" });
            DropIndex("dbo.PrivateChats", new[] { "UserTwo_Id" });
            RenameColumn(table: "dbo.GroupChats", name: "Groupmoderator_Id", newName: "GroupmoderatorId");
            RenameColumn(table: "dbo.Messages", name: "GroupChat_Id", newName: "GroupChatId");
            RenameColumn(table: "dbo.Messages", name: "PrivateChat_Id", newName: "PrivateChatId");
            RenameColumn(table: "dbo.PrivateChats", name: "UserOne_Id", newName: "UserOneId");
            RenameColumn(table: "dbo.PrivateChats", name: "UserTwo_Id", newName: "UserTwoId");
            RenameColumn(table: "dbo.Messages", name: "PublicChat_Id", newName: "PublicChatId");
            RenameIndex(table: "dbo.Messages", name: "IX_GroupChat_Id", newName: "IX_GroupChatId");
            RenameIndex(table: "dbo.Messages", name: "IX_PrivateChat_Id", newName: "IX_PrivateChatId");
            RenameIndex(table: "dbo.Messages", name: "IX_PublicChat_Id", newName: "IX_PublicChatId");
            CreateTable(
                "dbo.UserGroupChats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        GroupChatId = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.GroupChats", t => t.GroupChatId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.GroupChatId)
                .Index(t => t.ApplicationUser_Id);
            
            AddColumn("dbo.AspNetUsers", "IsBlocked", c => c.Boolean(nullable: false));
            AddColumn("dbo.GroupChats", "Password", c => c.String());
            AddColumn("dbo.Messages", "SenderId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.GroupChats", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.GroupChats", "GroupmoderatorId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Messages", "Content", c => c.String(nullable: false));
            AlterColumn("dbo.PrivateChats", "UserOneId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.PrivateChats", "UserTwoId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.PublicChats", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.GroupChats", "GroupmoderatorId");
            CreateIndex("dbo.Messages", "SenderId");
            CreateIndex("dbo.PrivateChats", "UserOneId");
            CreateIndex("dbo.PrivateChats", "UserTwoId");
            AddForeignKey("dbo.Messages", "SenderId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GroupChats", "GroupmoderatorId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PrivateChats", "UserOneId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PrivateChats", "UserTwoId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.AspNetUsers", "GroupChat_Id");
            DropColumn("dbo.Messages", "SenderName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "SenderName", c => c.String());
            AddColumn("dbo.AspNetUsers", "GroupChat_Id", c => c.Int());
            DropForeignKey("dbo.PrivateChats", "UserTwoId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PrivateChats", "UserOneId", "dbo.AspNetUsers");
            DropForeignKey("dbo.GroupChats", "GroupmoderatorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserGroupChats", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserGroupChats", "GroupChatId", "dbo.GroupChats");
            DropForeignKey("dbo.Messages", "SenderId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserGroupChats", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.PrivateChats", new[] { "UserTwoId" });
            DropIndex("dbo.PrivateChats", new[] { "UserOneId" });
            DropIndex("dbo.Messages", new[] { "SenderId" });
            DropIndex("dbo.GroupChats", new[] { "GroupmoderatorId" });
            DropIndex("dbo.UserGroupChats", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.UserGroupChats", new[] { "GroupChatId" });
            DropIndex("dbo.UserGroupChats", new[] { "UserId" });
            AlterColumn("dbo.PublicChats", "Name", c => c.String());
            AlterColumn("dbo.PrivateChats", "UserTwoId", c => c.String(maxLength: 128));
            AlterColumn("dbo.PrivateChats", "UserOneId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Messages", "Content", c => c.String());
            AlterColumn("dbo.GroupChats", "GroupmoderatorId", c => c.String(maxLength: 128));
            AlterColumn("dbo.GroupChats", "Name", c => c.String());
            DropColumn("dbo.Messages", "SenderId");
            DropColumn("dbo.GroupChats", "Password");
            DropColumn("dbo.AspNetUsers", "IsBlocked");
            DropTable("dbo.UserGroupChats");
            RenameIndex(table: "dbo.Messages", name: "IX_PublicChatId", newName: "IX_PublicChat_Id");
            RenameIndex(table: "dbo.Messages", name: "IX_PrivateChatId", newName: "IX_PrivateChat_Id");
            RenameIndex(table: "dbo.Messages", name: "IX_GroupChatId", newName: "IX_GroupChat_Id");
            RenameColumn(table: "dbo.Messages", name: "PublicChatId", newName: "PublicChat_Id");
            RenameColumn(table: "dbo.PrivateChats", name: "UserTwoId", newName: "UserTwo_Id");
            RenameColumn(table: "dbo.PrivateChats", name: "UserOneId", newName: "UserOne_Id");
            RenameColumn(table: "dbo.Messages", name: "PrivateChatId", newName: "PrivateChat_Id");
            RenameColumn(table: "dbo.Messages", name: "GroupChatId", newName: "GroupChat_Id");
            RenameColumn(table: "dbo.GroupChats", name: "GroupmoderatorId", newName: "Groupmoderator_Id");
            CreateIndex("dbo.PrivateChats", "UserTwo_Id");
            CreateIndex("dbo.PrivateChats", "UserOne_Id");
            CreateIndex("dbo.GroupChats", "Groupmoderator_Id");
            CreateIndex("dbo.AspNetUsers", "GroupChat_Id");
            AddForeignKey("dbo.PrivateChats", "UserTwo_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.PrivateChats", "UserOne_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.GroupChats", "Groupmoderator_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUsers", "GroupChat_Id", "dbo.GroupChats", "Id");
        }
    }
}
