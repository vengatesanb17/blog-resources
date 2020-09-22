using System;
using System.Linq;
using StudentManagement.Data.Models;

namespace StudentManagement.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return; // DB has been seeded
            }

            var students = new[]
            {
                new Student
                {
                    FirstName = "Carson", LastName = "Alexander", EnrollmentDate = DateTime.Parse("2005-09-01")
                },
                new Student
                {
                    FirstName = "Meredith", LastName = "Alonso", EnrollmentDate = DateTime.Parse("2002-09-01")
                },
                new Student {FirstName = "Arturo", LastName = "Anand", EnrollmentDate = DateTime.Parse("2003-09-01")},
                new Student
                {
                    FirstName = "Gytis", LastName = "Barzdukas", EnrollmentDate = DateTime.Parse("2002-09-01")
                },
                new Student {FirstName = "Yan", LastName = "Li", EnrollmentDate = DateTime.Parse("2002-09-01")},
                new Student {FirstName = "Peggy", LastName = "Justice", EnrollmentDate = DateTime.Parse("2001-09-01")},
                new Student {FirstName = "Laura", LastName = "Norman", EnrollmentDate = DateTime.Parse("2003-09-01")},
                new Student {FirstName = "Nino", LastName = "Olivetto", EnrollmentDate = DateTime.Parse("2005-09-01")}
            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }

            context.SaveChanges();
        }
    }
}