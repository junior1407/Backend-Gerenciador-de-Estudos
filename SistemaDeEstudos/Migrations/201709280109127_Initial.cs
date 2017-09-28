namespace SistemaDeEstudos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
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
                        StudySession_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StudySessions", t => t.StudySession_Id)
                .Index(t => t.StudySession_Id);
            
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
            
            CreateTable(
                "dbo.SessionParticipants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdStudySession = c.Int(nullable: false),
                        sample = c.Int(nullable: false),
                        ParticipantID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.ParticipantID, cascadeDelete: true)
                .ForeignKey("dbo.StudySessions", t => t.IdStudySession, cascadeDelete: true)
                .Index(t => t.IdStudySession)
                .Index(t => t.ParticipantID);
            
            CreateTable(
                "dbo.StudySessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        start = c.DateTime(nullable: false, precision: 0),
                        end = c.DateTime(nullable: false, precision: 0),
                        IdUser = c.Int(nullable: false),
                        IdSubject = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.IdUser, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.IdSubject, cascadeDelete: true)
                .Index(t => t.IdUser)
                .Index(t => t.IdSubject);
            
            CreateTable(
                "dbo.Times",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Start = c.String(nullable: false, unicode: false),
                        End = c.String(nullable: false, unicode: false),
                        idUser = c.Int(nullable: false),
                        idSession = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StudySessions", t => t.idSession, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.idUser, cascadeDelete: true)
                .Index(t => t.idUser)
                .Index(t => t.idSession);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Times", "idUser", "dbo.Users");
            DropForeignKey("dbo.Times", "idSession", "dbo.StudySessions");
            DropForeignKey("dbo.SessionParticipants", "IdStudySession", "dbo.StudySessions");
            DropForeignKey("dbo.StudySessions", "IdSubject", "dbo.Subjects");
            DropForeignKey("dbo.StudySessions", "IdUser", "dbo.Users");
            DropForeignKey("dbo.Users", "StudySession_Id", "dbo.StudySessions");
            DropForeignKey("dbo.SessionParticipants", "ParticipantID", "dbo.Users");
            DropForeignKey("dbo.Logins", "IdUser", "dbo.Users");
            DropForeignKey("dbo.StudentGrades", "IdUser", "dbo.Users");
            DropForeignKey("dbo.StudentGrades", "IdSubject", "dbo.Subjects");
            DropIndex("dbo.Times", new[] { "idSession" });
            DropIndex("dbo.Times", new[] { "idUser" });
            DropIndex("dbo.StudySessions", new[] { "IdSubject" });
            DropIndex("dbo.StudySessions", new[] { "IdUser" });
            DropIndex("dbo.SessionParticipants", new[] { "ParticipantID" });
            DropIndex("dbo.SessionParticipants", new[] { "IdStudySession" });
            DropIndex("dbo.StudentGrades", new[] { "IdSubject" });
            DropIndex("dbo.StudentGrades", new[] { "IdUser" });
            DropIndex("dbo.Users", new[] { "StudySession_Id" });
            DropIndex("dbo.Logins", new[] { "IdUser" });
            DropTable("dbo.Times");
            DropTable("dbo.StudySessions");
            DropTable("dbo.SessionParticipants");
            DropTable("dbo.Subjects");
            DropTable("dbo.StudentGrades");
            DropTable("dbo.Users");
            DropTable("dbo.Logins");
        }
    }
}
