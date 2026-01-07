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
    }
}
