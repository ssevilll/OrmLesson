namespace ObjectRelation.Lesson.Models
{
    internal class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Limit { get; set; }
        public List<Student> Students { get; set; }
        //one to many elaqe ucun cox teref az olanin idsini saxlayir, az teref cox teref ise list ile saxlayir
    }
}
