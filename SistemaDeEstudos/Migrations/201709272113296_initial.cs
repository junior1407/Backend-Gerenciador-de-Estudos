namespace SistemaDeEstudos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            //a
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, unicode: false),
                        Password = c.String(nullable: false, unicode: false),
                        IdUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.IdUser, cascadeDelete: true)
                .Index(t => t.IdUser);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Avatar = c.String(nullable: false, unicode: false),
                        Nickname = c.String(nullable: false, unicode: false),
                        idRedeSocial = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentGrades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUser = c.Int(nullable: false),
                        Grade = c.Int(nullable: false),
                        IdSubject = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subjects", t => t.IdSubject, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.IdUser, cascadeDelete: true)
                .Index(t => t.IdUser)
                .Index(t => t.IdSubject);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Logins", "IdUser", "dbo.Users");
            DropForeignKey("dbo.StudentGrades", "IdUser", "dbo.Users");
            DropForeignKey("dbo.StudentGrades", "IdSubject", "dbo.Subjects");
            DropIndex("dbo.StudentGrades", new[] { "IdSubject" });
            DropIndex("dbo.StudentGrades", new[] { "IdUser" });
            DropIndex("dbo.Logins", new[] { "IdUser" });
            DropTable("dbo.Subjects");
            DropTable("dbo.StudentGrades");
            DropTable("dbo.Users");
            DropTable("dbo.Logins");
        }
    }
}
