namespace WebApplication5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookTitle = c.String(),
                        AuthorName = c.String(),
                        BorrowingDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ReturningDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        StudentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GenreType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentName = c.String(nullable: false, maxLength: 50),
                        Address = c.String(maxLength: 250),
                        Email = c.String(maxLength: 50),
                        GenreId = c.Int(nullable: false),
                        MembershipFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsStudent = c.Boolean(nullable: false),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.UserInfoes",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.UserName);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Books", "StudentId", "dbo.Students");
            DropIndex("dbo.Students", new[] { "GenreId" });
            DropIndex("dbo.Books", new[] { "StudentId" });
            DropTable("dbo.UserInfoes");
            DropTable("dbo.Students");
            DropTable("dbo.Genres");
            DropTable("dbo.Books");
        }
    }
}
