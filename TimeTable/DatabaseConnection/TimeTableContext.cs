using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;

namespace TimeTable.DatabaseConnection
{
    public class TimeTableContext : DbContext
    {
        string connectionstring = "server = localhost;  database = timetable; uid = root; pwd = Luna07wenn!";

		public DbSet<Subject> Subjects { get; set; }
        public DbSet<Student> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionstring, ServerVersion.AutoDetect(connectionstring));
        }

        public void InitializeDatabase()
        {
            Database.Migrate();
        }
    }
}