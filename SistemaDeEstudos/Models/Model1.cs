namespace SistemaDeEstudos.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

  [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model11")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public System.Data.Entity.DbSet<SistemaDeEstudos.Models.Times> Times { get; set; }

        public System.Data.Entity.DbSet<SistemaDeEstudos.Models.StudySession> StudySessions { get; set; }

        public System.Data.Entity.DbSet<SistemaDeEstudos.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<SistemaDeEstudos.Models.Subject> Subjects { get; set; }

        public System.Data.Entity.DbSet<SistemaDeEstudos.Models.StudentGrade> StudentGrades { get; set; }

        public System.Data.Entity.DbSet<SistemaDeEstudos.Models.SessionParticipants> SessionParticipants { get; set; }

        public System.Data.Entity.DbSet<SistemaDeEstudos.Models.Login> Logins { get; set; }
    }
}
