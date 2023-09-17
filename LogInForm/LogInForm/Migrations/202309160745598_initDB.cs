namespace LogInForm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        phone = c.String(),
                        Gender = c.String(),
                        username = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        phone = c.String(),
                        Gender = c.String(),
                        username = c.String(),
                        password = c.String(),
                        T_Id = c.Int(nullable: false),
                        A_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admins", t => t.A_Id, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.T_Id, cascadeDelete: false)
                .Index(t => t.T_Id)
                .Index(t => t.A_Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        phone = c.String(),
                        Gender = c.String(),
                        username = c.String(),
                        password = c.String(),
                        Admin_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Admins", t => t.Admin_Id, cascadeDelete: true)
                .Index(t => t.Admin_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "T_Id", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "Admin_Id", "dbo.Admins");
            DropForeignKey("dbo.Students", "A_Id", "dbo.Admins");
            DropIndex("dbo.Teachers", new[] { "Admin_Id" });
            DropIndex("dbo.Students", new[] { "A_Id" });
            DropIndex("dbo.Students", new[] { "T_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
            DropTable("dbo.Admins");
        }
    }
}
