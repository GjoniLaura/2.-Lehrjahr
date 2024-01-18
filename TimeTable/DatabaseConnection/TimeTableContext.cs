using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using TimeTable.Modules;

namespace TimeTable.DatabaseConnection
{
    public class TimeTableContext : DbContext
    {
        string connectionstring = "server = localhost;  database = timetable; persistsecurityinfo=True; uid = root; pwd = Luna07wenn!";

		public DbSet<Subject> subject { get; set; }
        public DbSet<Student> student { get; set; }
        public DbSet<Teacher> teacher { get; set; }
        public DbSet<Education> education { get; set; }
        public DbSet<ClockTimes> time { get; set; }
        public DbSet<Person> person { get; set; }
        public DbSet<Room> room { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionstring, ServerVersion.AutoDetect(connectionstring));

        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Teacher>().ToTable("teacher");
			modelBuilder.Entity<Student>().ToTable("student");

            modelBuilder.Entity<Teacher>()
                .HasMany(x => x.TeachedSubject)
                .WithMany(y => y.teachers)
                .UsingEntity(j => j.ToTable("TeacherSubjects"));

            modelBuilder.Entity<Teacher>()
                .HasMany(x => x.UnavailableTimeSlots)
                .WithMany(y => y.teachers)
                .UsingEntity(j => j.ToTable("TeacherUnavailabel"));

			modelBuilder.Entity<Teacher>()
	        .HasOne(t => t.Person)
	        .WithOne()
	        .HasForeignKey<Teacher>(t => t.Id);

            modelBuilder.Entity<Student>()
                .HasMany(x => x.Teachers)
                .WithMany(y => y.Students)
                .UsingEntity(j => j.ToTable("StudentTeachers"));

			modelBuilder.Entity<Student>()
	        .HasOne(s => s.Person)
	        .WithOne()
	        .HasForeignKey<Student>(s => s.Id);

            modelBuilder.Entity<Education>()
                .HasMany(x => x.Subjects)
                .WithMany(y => y.educations)
                .UsingEntity(j => j.ToTable("EducationSubjects"));
            modelBuilder.Entity<Education>()
                .HasMany(x => x.Students)
                .WithOne(y => y.Education);
		}

		public void InitializeDatabase()
        {
           Database.Migrate();
        }
    }
}