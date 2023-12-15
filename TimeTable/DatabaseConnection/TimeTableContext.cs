using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;

namespace TimeTable.DatabaseConnection
{
    public class TimeTableContext : DbContext
    {
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Student> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server = localhost; database = timetable; uid = root; pwd = Luna07wenn!", ServerVersion.AutoDetect("server = localhost; database = timetable; uid = root; pwd = Luna07wenn!"));
        }

        public void InitializeDatabase()
        {
            Database.Migrate();
        }
    }
}