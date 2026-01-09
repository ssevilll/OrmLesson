using Microsoft.EntityFrameworkCore;
using ObjectRelation.Lesson.Models;

namespace ObjectRelation.Lesson.Data
{
    internal class AppDbContext : DbContext
    {
        public DbSet <Student> Students { get; set; }
        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=ObjectRelationLessonDb;Trusted_Connection=True;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasKey(s => s.Id); //primary key
            //modelBuilder.Entity<Student>().Property(s => s.Name).IsRequired().HasMaxLength(100);   //student classde [Required] ve [MaxLength(100)] yazdigimiz ucun bu setiri yazmaga ehtiyac qalmir
            base.OnModelCreating(modelBuilder);
        }
    }
}
