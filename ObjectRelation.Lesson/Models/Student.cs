using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectRelation.Lesson.Models
{
    internal class Student
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        public int Age { get; set; }
        public int? GroupId { get; set; } //nullable olmalidir ki group olmayan studentlerde problem olmasin
        public Group Group { get; set; } //navigation olmalidir ki groupid ile student arasindaki elaqeni qura bilsin
        public StudentDetail StudentDetail { get; set; } //subjectden studente ordan detaile kecmek olsun
        public List<SubjectStudent> SubjectStudents { get; set; } //many to many elaqe ucun
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Description: {Description}, Age: {Age}";
        }
    }
}
