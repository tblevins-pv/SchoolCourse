using System;
using System.Linq;
using EFGetStarted;

namespace SchoolCourse
{
    internal class Program
    {
        private static void Main()
        {
            using var db = new SchoolContext();

            Console.WriteLine("Inserting new Student");
            db.Add(new Student {Name = "Thomas"});
            db.SaveChanges();
            
            Console.WriteLine("Inserting new Course");
            db.Add(new Course {CourseName = "English"});
            db.SaveChanges();
            
            // Read
            Console.WriteLine("Getting Student");
            var student = db.Students.First(s => s.Name == "Thomas");
            
            Console.WriteLine("Getting Course");
            var course = db.Courses.First(s => s.CourseName == "English");
            
            Console.WriteLine("Establishing StudentCourse relationship");
            db.StudentCourses.Add(new StudentCourse
            {
                Student = student,
                Course = course
            });

            db.SaveChanges();
            
            // Get a handle on student
            var new_student = new Student {Name = "Thomas"};
            // Access via handle
            // student.Courses;

            var courses = db.Students
                .Where(s => s.Name == "Thomas")
                .SelectMany(p => p.StudentCourses)
                .Select(pc => pc.Course).ToList();

            Console.WriteLine("Courses for Student:");
            foreach (var item in courses)
            {
                Console.WriteLine(item.CourseName);
            }
        }
    }
}
