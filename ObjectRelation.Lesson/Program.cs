using ObjectRelation.Lesson.Data;
using ObjectRelation.Lesson.Models;

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
            query = query.OrderByDescending(s => s.Age); //yasina gore azalan sira ile duzur
            query = query.Skip(2); //ilk 2 datani skip edir
            query = query.Take(3); //sonra 3 data goturur
            var st3 = query.ToList(); //sqlde birlesdirilir liste cevirir

            //yalniz adlar gelir (list string listi olur)
            var st4 = context.Students
                .Select(s => s.Name)
                .ToList();

            //yalniz id ve adlar gelir (StudentDto tipinde list olur) (studentdto classi olmasa idi anonim tipde gelirdi)
            var st5 = context.Students
                .Select(s => new StudentDto
                {
                    Id = s.Id,
                    Name = s.Name
                })
                .ToList();


            //insert
            var newstudent = new Student
            {
                Name = "New Student",
                Age = 22,
                Description = "Description of new student"
            };
            context.Students.Add(newstudent); //ancaq student tipi gondere bilerik
            //context.Add(newstudent); (tablein adini yazmasan da olar, cunku context bilirr hansi table aiddir)
            int result = context.SaveChanges(); //baza yazir, commit elemek ucun (run eleyirik add olunmus olur)
            if (result > 0)
                Console.WriteLine("Student added successfully.");
            else
                Console.WriteLine("Error adding student.");


            //bulk insert
            var studentsToAdd = new List<Student>
            {
                new Student { Name = "Student 1", Age = 20, Description = "Description 1" },
                new Student { Name = "Student 2", Age = 21, Description = "Description 2" },
                new Student { Name = "Student 3", Age = 22, Description = "Description 3" }
            };

            context.Students.AddRange(studentsToAdd); //bir nece deyeri add edir
            context.SaveChanges(); //save edir


            //delete
            var studentToDelete = context.Students.Find(2); //id si 2 olan student
            if (studentToDelete != null) //eger bele student varsa
            {
                context.Students.Remove(studentToDelete); //silir
                context.SaveChanges(); // save edir
                Console.WriteLine("Student deleted successfully.");
            }
            else
                Console.WriteLine("Student not found.");


            //update
            var studentToUpdate = context.Students.Find(3); //id si 3 olan student
            if (studentToUpdate != null) {
                studentToUpdate.Name = "Updated Name"; //adini deyisir
                studentToUpdate.Age = 25; //yasini deyisir
                studentToUpdate.Description = "Updated Description"; //description deyisir
                context.SaveChanges(); //save edir
                Console.WriteLine("Student updated successfully.");
            }
            else
                Console.WriteLine("Student not found.");


            var newst= new Student
            {
                Name = "Another New Student",
                Age = 23,
                Description = "Description of another new student"
            };
            context.Students.Update(newst); //insert kimi isleyir eger id yoxdursa, update kimi isleyir eger id varsa
            context.SaveChanges(); //baza yazir


            //constraints


        }
    }
    class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
