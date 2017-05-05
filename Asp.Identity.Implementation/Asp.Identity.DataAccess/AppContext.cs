using Asp.Identity.DataAccess.Migrations;
using Asp.Identity.Domain.Entities;
using System.Data.Entity;

namespace Asp.Identity.DataAccess
{
    public class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<LoginHistory> LoginHistories { get; set; }

        public DbSet<WorkForm> Forms { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<PossibleAnswer> PossibleAnswers { get; set; }

        public DbSet<UserForm> UserForms { get; set; }
        public DbSet<UserAnswer> Answers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppContext, Configuration>());
        }

        public AppContext()
            : base("DefaultConnection")
        { }
    }
}
