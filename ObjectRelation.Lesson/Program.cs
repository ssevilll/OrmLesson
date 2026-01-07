using ObjectRelation.Lesson.Data;

namespace ObjectRelation.Lesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppDbContext context = new AppDbContext();

            //butun datalar gelir
            var students = context.Students.ToList();
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }

            //bir data gelir
            var st = context.Students.Find(1);
            Console.WriteLine(st);



            var st1 = context.Students.
                Where(s => s.Age >= 20)
                .ToList();
            foreach (var student in st1)
            {
                Console.WriteLine(student);
            }

            //filterlenmis datalar gelir birbasa (rama cekib ramda filterleme!)
            var st2 = context.Students.
                Where(s => s.Name.Contains("a"))
                .ToList();
            foreach (var student in st2)
            {
                Console.WriteLine(student);
            }

            //bir nece deyisiklik edende
            var query = context.Students.
                Where(s => s.Id > 5);
            query=query.OrderByDescending(s=> s.Age); //yasina gore azalan sira ile duzur
            query =query.Skip(2); //ilk 2 datani skip edir
            query =query.Take(3); //sonra 3 data goturur
            var st3 = query.ToList(); //sqlde birlesdirilir liste cevirir

            //yalniz adlar gelir (list string listi olur)
            var st4 = context.Students
                .Select(s=>s.Name)
                .ToList();

            //yalniz id ve adlar gelir (StudentDto tipinde list olur) (studentdto classi olmasa idi anonim tipde gelirdi)
            var st5 = context.Students
                .Select(s=>new StudentDto
                {
                    Id=s.Id,
                    Name=s.Name
                })
                .ToList();
        }
    }
    class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
