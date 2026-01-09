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
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Description: {Description}, Age: {Age}";
        }
    }
}
