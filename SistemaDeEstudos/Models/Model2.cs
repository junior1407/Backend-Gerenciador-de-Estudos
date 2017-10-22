namespace SistemaDeEstudos.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public partial class Model2 : DbContext
    {
        public Model2()
          //   : base("name=Model2")
          : base("Model2")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
        public System.Data.Entity.DbSet<SistemaDeEstudos.Models.DaysofTheWeek> DaysofTheWeeks { get; set; }
        public System.Data.Entity.DbSet<SistemaDeEstudos.Models.Times> Times { get; set; }

        public System.Data.Entity.DbSet<SistemaDeEstudos.Models.StudySession> StudySessions { get; set; }

        public System.Data.Entity.DbSet<SistemaDeEstudos.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<SistemaDeEstudos.Models.StudentSubject> StudentSubjects { get; set; }

        public System.Data.Entity.DbSet<SistemaDeEstudos.Models.SessionParticipants> SessionParticipants { get; set; }

        public System.Data.Entity.DbSet<SistemaDeEstudos.Models.Login> Logins { get; set; }
        public System.Data.Entity.DbSet<SistemaDeEstudos.Models.LoginToken> LoginTokens { get; set; }

    }
}
