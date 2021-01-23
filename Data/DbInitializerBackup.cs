/*using BitcubeEval.Models;
using System;
using System.Linq;

namespace BitcubeEval.Data
{
    public class DbInitializer
    {
        public static void Initialize(CollegeContext context)
        {
            //context.Database.EnsureCreated();

            if (context.Lecturers.Any())
            {
                return;
            }

            var lecturers = new Lecturer[]
            {
                new Lecturer{Forenames = "Mara Jade", Surname = "Phoenix",
                    DateOfBirth = DateTime.Parse("1992-02-26"),
                    Email="mjphoenix@mail.org"},
                new Lecturer{Forenames = "Linda Sam", Surname = "Muridzi",
                    DateOfBirth = DateTime.Parse("1995-08-22"),
                   Email="lsmuridzi@mail.org"},
            };
            foreach (Lecturer l in lecturers)
            {
                context.Lecturers.Add(l);
            }
            context.SaveChanges();

            var degrees = new Degree[]
            {
                new Degree{DegreeName = "Basic Mathematics", DegreeDuration = 1,
                    LecturerID = 2},
                new Degree{DegreeName = "Intermediate Mathematics", DegreeDuration = 2,
                    LecturerID = 2},
                new Degree{DegreeName = "Advanced Mathematics", DegreeDuration = 1,
                    LecturerID = 1},
            };
            foreach (Degree d in degrees)
            {
                context.Degrees.Add(d);
            }
            context.SaveChanges();

            *//*var degrees = new Degree[]
            {
                new Degree{DegreeName = "Basic Mathematics", DegreeDuration = 1,
                    LecturerID = lecturers.Single(l => l.Surname == "Muridzi").ID},
                new Degree{DegreeName = "Intermediate Mathematics", DegreeDuration = 2,
                    LecturerID = lecturers.Single(l => l.Surname == "Muridzi").ID},
                new Degree{DegreeName = "Advanced Mathematics", DegreeDuration = 1,
                    LecturerID = lecturers.Single(l => l.Surname == "Phoenix").ID},
            };
            foreach (Degree d in degrees)
            {
                context.Degrees.Add(d);
            }
            context.SaveChanges();*//*

            var students = new Student[]
            {
                new Student{Forenames = "Jarhn Felix", Surname = "Schmidt",
                    DateOfBirth = DateTime.Parse("2000-09-01"),
                    DegreeID = 1,
                    Email="jfschmidt@mail.org"},
                new Student{Forenames = "Jada Pinkett", Surname = "Smith",
                    DateOfBirth = DateTime.Parse("2002-03-05"),
                    DegreeID = 2,
                    Email="jpsmith@mail.org"},
                new Student{Forenames = "Mike", Surname = "Somara",
                    DateOfBirth = DateTime.Parse("2000-06-15"),
                    DegreeID = 3,
                    Email="msomara@mail.org"},
            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            *//*var students = new Student[]
            {
                new Student{Forenames = "Jarhn Felix", Surname = "Schmidt",
                    DateOfBirth = DateTime.Parse("2000-09-01"),
                    //DegreeID = degrees.Single(d => d.DegreeName == "Basic Mathematics").DegreeID,
                    Email="jfschmidt@mail.org"},
                new Student{Forenames = "Jada Pinkett", Surname = "Smith",
                    DateOfBirth = DateTime.Parse("2002-03-05"),
                    //DegreeID = degrees.Single(d => d.DegreeName == "Intermediate Mathematics").DegreeID,
                    Email="jpsmith@mail.org"},
                new Student{Forenames = "Mike", Surname = "Somara",
                    DateOfBirth = DateTime.Parse("2000-06-15"),
                    //DegreeID = degrees.Single(d => d.DegreeName == "Advanced Mathematics").DegreeID,
                    Email="msomara@mail.org"},
            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();*//*

            var courses = new Course[]
            {
                new Course{CourseName = "Linear Algebra", CourseDuration = 6,
                    DegreeID = 1},
                new Course{CourseName = "Mathematical Analysis I", CourseDuration = 3,
                    DegreeID = 1},
                new Course{CourseName = "Multivariate Calculus", CourseDuration = 6,
                    DegreeID = 2},
                new Course{CourseName = "Mathematical Analysis II", CourseDuration = 6,
                    DegreeID = 2},
                new Course{CourseName = "Mathematical Analysis III", CourseDuration = 6,
                    DegreeID = 3},
                new Course{CourseName = "Linear Algebra II", CourseDuration = 6,
                    DegreeID = 2},
                new Course{CourseName = "Topology I", CourseDuration = 6,
                    DegreeID = 2},
                new Course{CourseName = "Abstract Mathematics I", CourseDuration = 6,
                    DegreeID = 1},
                new Course{CourseName = "Mathematical Analysis IV", CourseDuration = 6,
                    DegreeID = 1},
            };
            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            *//*var courses = new Course[]
            {
                new Course{CourseName = "Linear Algebra", CourseDuration = 6,
                    DegreeID = degrees.Single(d => d.DegreeName == "Basic Mathematics").DegreeID},
                new Course{CourseName = "Mathematical Analysis I", CourseDuration = 3,
                    DegreeID = degrees.Single(d => d.DegreeName == "Basic Mathematics").DegreeID},
                new Course{CourseName = "Multivariate Calculus", CourseDuration = 6,
                    DegreeID = degrees.Single(d => d.DegreeName == "Intermediate Mathematics").DegreeID},
                new Course{CourseName = "Mathematical Analysis II", CourseDuration = 6,
                    DegreeID = degrees.Single(d => d.DegreeName == "Intermediate Mathematics").DegreeID},
                new Course{CourseName = "Mathematical Analysis III", CourseDuration = 6,
                    DegreeID = degrees.Single(d => d.DegreeName == "Advanced Mathematics").DegreeID},
                new Course{CourseName = "Linear Algebra II", CourseDuration = 6,
                    DegreeID = degrees.Single(d => d.DegreeName == "Intermediate Mathematics").DegreeID},
                new Course{CourseName = "Topology I", CourseDuration = 6,
                    DegreeID = degrees.Single(d => d.DegreeName == "Intermediate Mathematics").DegreeID},
                new Course{CourseName = "Abstract Mathematics I", CourseDuration = 6,
                    DegreeID = degrees.Single(d => d.DegreeName == "Basic Mathematics").DegreeID},
                new Course{CourseName = "Mathematical Analysis IV", CourseDuration = 6,
                    DegreeID = degrees.Single(d => d.DegreeName == "Advanced Mathematics").DegreeID},
            };
            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();*//*
        }
        
    }
}
*/