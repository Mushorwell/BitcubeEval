using BitcubeEval.Models;
using Microsoft.EntityFrameworkCore;

namespace BitcubeEval.Data
{
    public class CollegeContext : DbContext
    {
        public CollegeContext(DbContextOptions<CollegeContext> options) : base(options)
        {
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Degree> Degrees { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Degree>().ToTable("Degree");
            modelBuilder.Entity<Lecturer>().ToTable("Lecturer");
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Student>().ToTable("Student");
        }

    }
}

/*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course")
                *//*.HasOne(c=>c.Degree)
                .WithMany()                
                .OnDelete(DeleteBehavior.Restrict)*//*;
            modelBuilder.Entity<Degree>().ToTable("Degree")
                *//*.HasOne(d => d.Lecturer)
                .WithMany()
                .HasForeignKey(d => d.LecturerID)
                .OnDelete(DeleteBehavior.Restrict)*//*;
            modelBuilder.Entity<Lecturer>().ToTable("Lecturer");
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Student>().ToTable("Student")
                *//*.HasOne(s => s.Degree)
                .WithMany()
                .HasForeignKey(s=>s.DegreeID)
                .OnDelete(DeleteBehavior.Restrict)*//*;
        }*/
