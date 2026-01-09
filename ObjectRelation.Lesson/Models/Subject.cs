namespace ObjectRelation.Lesson.Models
{
    internal class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SubjectStudent> SubjectStudents { get; set; } //many to many elaqe ucun
    }
}
