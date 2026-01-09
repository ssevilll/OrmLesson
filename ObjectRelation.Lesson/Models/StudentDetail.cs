using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectRelation.Lesson.Models
{
    internal class StudentDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
        public string GroupName { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
