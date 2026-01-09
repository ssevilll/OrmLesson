using Microsoft.EntityFrameworkCore;
using ObjectRelation.Lesson.Models;

namespace ObjectRelation.Lesson.Data
{
    internal class AppDbContext : DbContext
    {
        public DbSet <Student> Students { get; set; } //table yaratmaq ucun
        public DbSet<Group> Groups { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectStudent> SubjectStudents { get; set; }
        public DbSet<StudentDetail> StudentDetails { get; set; }

        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=ObjectRelationLessonDb;Trusted_Connection=True;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasKey(s => s.Id); //primary key
            modelBuilder.Entity<SubjectStudent>().HasKey(ss => new {ss.SubjectId,ss.StudentId}); //composite primary key

            //bazada olan dataya yeni column add etsek onu nullable etmeliyik
            //meselen student tableda groupid columnuna yeni elave etdikde bazada olan datalarin hamisina default olaraq null deyer verilir

            //modelBuilder.Entity<Student>().Property(s => s.Name).IsRequired().HasMaxLength(100);   //student classde [Required] ve [MaxLength(100)] yazdigimiz ucun bu setiri yazmaga ehtiyac qalmir
            base.OnModelCreating(modelBuilder);
        }
    }
}
