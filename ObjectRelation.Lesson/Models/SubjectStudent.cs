namespace ObjectRelation.Lesson.Models
{
    internal class SubjectStudent
    {
        //many to manyde pivot tablede id olmur amma primary key olmasi ucun bele edirik
        //hem subject id hem student id birlesib primary key olur
        //attributelarla da bunu ede bilmirik
        //instead appdbcontextde onmodelcreatingde yazmaliyiq
        public int SubjectId { get; set; }
        public Subject subject { get; set; } //navigation ucun
        public int StudentId { get; set; }
        public Student student { get; set; }

        //kenarlar ortani list kimi saxlamalidi
    }
}
