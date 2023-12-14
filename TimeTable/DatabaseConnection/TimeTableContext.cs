using Microsoft.EntityFrameworkCore;
namespace TimeTable.DatabaseConnection
{
    public class TimeTableContext
    {
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Student> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("your-connection-string", ServerVersion.AutoDetect("your-connection-string"));
        }

        public void InitializeDatabase()
        {
            Migrate();
        }
    }
}