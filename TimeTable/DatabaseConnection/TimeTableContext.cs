using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;

namespace TimeTable.DatabaseConnection
{
    public class TimeTableContext : DbContext
    {
        string connectionstring = "server = localhost;  database = timetabel; persistsecurityinfo=True; uid = root; pwd = Luna07wenn!";

		public DbSet<Subject> subject { get; set; }
        public DbSet<Student> student { get; set; }
        public DbSet<Teacher> teacher { get; set; }
        public DbSet<Education> education { get; set; }
        public DbSet<ClockTimes> time { get; set; }
        public DbSet<Person> person { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionstring, ServerVersion.AutoDetect(connectionstring));
        }

        public void InitializeDatabase()
        {
            this.Database.Migrate();
        }
    }
}