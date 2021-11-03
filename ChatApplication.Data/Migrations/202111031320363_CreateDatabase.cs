namespace ChatApplication.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GroupChats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        SendDate = c.DateTime(nullable: false),
                        ReadByReciever = c.Boolean(nullable: false),
                        SenderName = c.String(),
                        GroupChat_Id = c.Int(nullable: true),
                        PrivateChat_Id = c.Int(nullable: true),
                        PublicChat_Id = c.Int(nullable: true),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GroupChats", t => t.GroupChat_Id)
                .ForeignKey("dbo.PrivateChats", t => t.PrivateChat_Id)
                .ForeignKey("dbo.PublicChats", t => t.PublicChat_Id)
                .Index(t => t.GroupChat_Id)
                .Index(t => t.PrivateChat_Id)
                .Index(t => t.PublicChat_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        GroupChat_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GroupChats", t => t.GroupChat_Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.GroupChat_Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.PrivateChats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserOne_Id = c.String(maxLength: 128),
                        UserTwo_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserOne_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserTwo_Id)
                .Index(t => t.UserOne_Id)
                .Index(t => t.UserTwo_Id);
            
            CreateTable(
                "dbo.PublicChats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Messages", "PublicChat_Id", "dbo.PublicChats");
            DropForeignKey("dbo.PrivateChats", "UserTwo_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.PrivateChats", "UserOne_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "PrivateChat_Id", "dbo.PrivateChats");
            DropForeignKey("dbo.AspNetUsers", "GroupChat_Id", "dbo.GroupChats");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "GroupChat_Id", "dbo.GroupChats");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PrivateChats", new[] { "UserTwo_Id" });
            DropIndex("dbo.PrivateChats", new[] { "UserOne_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "GroupChat_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Messages", new[] { "PublicChat_Id" });
            DropIndex("dbo.Messages", new[] { "PrivateChat_Id" });
            DropIndex("dbo.Messages", new[] { "GroupChat_Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PublicChats");
            DropTable("dbo.PrivateChats");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Messages");
            DropTable("dbo.GroupChats");
        }
    }
}
