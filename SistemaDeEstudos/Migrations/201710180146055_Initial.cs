namespace SistemaDeEstudos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DaysofTheWeeks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.StudentSubjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUser = c.Int(nullable: false),
                        Grade = c.Int(nullable: false),
                        Subject = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.IdUser, cascadeDelete: true)
                .Index(t => t.IdUser);
            
            CreateTable(
                "dbo.LoginTokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Token = c.String(unicode: false),
                        Reset_token = c.String(unicode: false),
                        Start = c.DateTime(nullable: false, precision: 0),
                        End = c.DateTime(nullable: false, precision: 0),
                        IdUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.IdUser, cascadeDelete: true)
                .Index(t => t.IdUser);
            
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
                        IdStudentSubject = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.IdUser, cascadeDelete: true)
                .ForeignKey("dbo.StudentSubjects", t => t.IdStudentSubject, cascadeDelete: true)
                .Index(t => t.IdUser)
                .Index(t => t.IdStudentSubject);
            
            CreateTable(
                "dbo.Times",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Start = c.String(nullable: false, unicode: false),
                        End = c.String(nullable: false, unicode: false),
                        idUser = c.Int(nullable: false),
                        idDay = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DaysofTheWeeks", t => t.idDay, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.idUser, cascadeDelete: true)
                .Index(t => t.idUser)
                .Index(t => t.idDay);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Times", "idUser", "dbo.Users");
            DropForeignKey("dbo.Times", "idDay", "dbo.DaysofTheWeeks");
            DropForeignKey("dbo.SessionParticipants", "IdStudySession", "dbo.StudySessions");
            DropForeignKey("dbo.StudySessions", "IdStudentSubject", "dbo.StudentSubjects");
            DropForeignKey("dbo.StudySessions", "IdUser", "dbo.Users");
            DropForeignKey("dbo.SessionParticipants", "ParticipantID", "dbo.Users");
            DropForeignKey("dbo.LoginTokens", "IdUser", "dbo.Users");
            DropForeignKey("dbo.Logins", "IdUser", "dbo.Users");
            DropForeignKey("dbo.StudentSubjects", "IdUser", "dbo.Users");
            DropIndex("dbo.Times", new[] { "idDay" });
            DropIndex("dbo.Times", new[] { "idUser" });
            DropIndex("dbo.StudySessions", new[] { "IdStudentSubject" });
            DropIndex("dbo.StudySessions", new[] { "IdUser" });
            DropIndex("dbo.SessionParticipants", new[] { "ParticipantID" });
            DropIndex("dbo.SessionParticipants", new[] { "IdStudySession" });
            DropIndex("dbo.LoginTokens", new[] { "IdUser" });
            DropIndex("dbo.StudentSubjects", new[] { "IdUser" });
            DropIndex("dbo.Logins", new[] { "IdUser" });
            DropTable("dbo.Times");
            DropTable("dbo.StudySessions");
            DropTable("dbo.SessionParticipants");
            DropTable("dbo.LoginTokens");
            DropTable("dbo.StudentSubjects");
            DropTable("dbo.Users");
            DropTable("dbo.Logins");
            DropTable("dbo.DaysofTheWeeks");
        }
    }
}
