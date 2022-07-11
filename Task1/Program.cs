using Microsoft.EntityFrameworkCore;
using Task1.Model;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Address address1 = new Address() { FullAddress = "Адрес1" };
            Address address2 = new Address() { FullAddress = "Адрес2" };
            Address address3 = new Address() { FullAddress = "Адрес3" };

            Student student1 = new Student() { Name = "Студент1" };
            Student student2 = new Student() { Name = "Студент2" };
            Student student3 = new Student() { Name = "Студент3" };
            Student student4 = new Student() { Name = "Студент4" };

            Course course1 = new Course() { Name = "Информатика" };
            Course course2 = new Course() { Name = "Математика" };
            Course course3 = new Course() { Name = "Литература" };


            student1.Address = address1;
            student2.Address = address1;
            student3.Address = address1;
            student4.Address = address1;

            address1.Courses.Add(course1);
            address2.Courses.Add(course2);
            address3.Courses.Add(course3);

            course1.Addresses.Add(address1);
            course2.Addresses.Add(address2);
            course3.Addresses.Add(address3);
            course3.Addresses.Add(address2);

            address1.Students.Add(student1);
            address2.Students.Add(student2);
            address1.Students.Add(student3);
            address1.Students.Add(student4);

            student1.Courses.Add(course1);
            student1.Courses.Add(course2);
            student1.Courses.Add(course3);
            student2.Courses.Add(course1);
            student2.Courses.Add(course2);
            student3.Courses.Add(course1);
            student4.Courses.Add(course3);

            course1.Students.Add(student1);
            course1.Students.Add(student2);
            course1.Students.Add(student3);
            course2.Students.Add(student1);
            course2.Students.Add(student2);
            course3.Students.Add(student1);
            course3.Students.Add(student4);

            using (Context context = new Context())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Courses.AddRange(course1, course2, course3);
                context.Students.AddRange(student1, student2, student3, student4);
                context.Addresses.AddRange(address1, address2, address3);
                context.SaveChanges();
            }

            using (Context context = new Context())
            {
                //context.Addresses.Load();
                //context.Courses.Load();
                //context.Students.Load();                

                Console.WriteLine("Students:");
                foreach (Student student in context.Students.Include(s => s.Courses).Include(s => s.Address))
                {
                    Console.WriteLine(student);
                }

                Console.WriteLine("\nAddresses");
                foreach (Address address in context.Addresses.Include(a => a.Students).Include(a => a.Courses))
                {
                    Console.WriteLine(address);
                }

                Console.WriteLine("\nCoureses");
                foreach (Course course in context.Courses.Include(c => c.Students))
                {
                    Console.WriteLine(course);
                }
            }

            using (Context context = new Context())
            {
                //Добавляем адрес без адреса
                Address addressTest1 = new Address();
                try
                {
                    context.Addresses.Add(addressTest1);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
            }

            using (Context context = new Context())
            {
                //Добавляем повторный адрес
                Address addressTest2 = new Address() { FullAddress = "Адрес1" };
                try
                {
                    context.Addresses.Add(addressTest2);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
        }
    }
}