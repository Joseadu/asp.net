using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace platzi_school.Models
{
    public class SchoolContext: DbContext
    {
        public DbSet<School> Schools { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Assessment> Assessments { get; set; }

        public SchoolContext(DbContextOptions<SchoolContext> options): base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            School school = new School()
            {
                Name = "Platzi",
                Id = Guid.NewGuid().ToString(),
                CreationDate = 2006,
                Country = "España",
                City = "Málaga",
                Dirección = "Avenida Alameda"
            };

            // Cargar cursos
            var grades = ChargeGrades(school);

            // Para cada curso cargar asignaturas
            var subjects = ChargeSubjects(grades);

            // Para cada estudiante cargar cursos
            var students = ChargeStudent(grades);

            modelBuilder.Entity<School>().HasData(school);
            modelBuilder.Entity<Grade>().HasData(grades.ToArray());
            modelBuilder.Entity<Subject>().HasData(subjects.ToArray());
            modelBuilder.Entity<Student>().HasData(students.ToArray());
        }

        
        private List<Student> ChargeStudent(List<Grade> grades)
        {
            var studentList = new List<Student>();
            Random rnd = new Random();
            foreach (var grade in grades)
            {
                int cantRandom = rnd.Next(5, 20);
                var tempList = RandomStudentGenerator(grade, cantRandom);
                studentList.AddRange(tempList);
            }
            return studentList;
        }

        private static List<Subject> ChargeSubjects(List<Grade> grades)
        {
            var completedList = new List<Subject>();
            foreach (var grade in grades)
            {
                var tempList = new List<Subject> {
                    new Subject {
                        Name = "React",
                        Id = Guid.NewGuid().ToString(),
                        GradeId = grade.Id
                    },
                    new Subject {
                        Name = "Angular",
                        Id = Guid.NewGuid().ToString()
                    },
                    new Subject {
                        Name = "Javascript",
                        Id = Guid.NewGuid().ToString()
                    },
                    new Subject {
                        Name = "C#",
                        Id = Guid.NewGuid().ToString()
                    }
                };
                completedList.AddRange(tempList);
                // grade.Subjects = tempList;
            }
            return completedList;
        }

        public static List<Grade> ChargeGrades(School school)
        {
             return new List<Grade>()
            {
                new Grade()
                {
                    Id = Guid.NewGuid().ToString(),
                    SchoolId = school.Id,
                    Name = "101",
                    TypeDay = TypeDay.Morning,
                    Dirección=""
                },
                new Grade()
                {
                    Id = Guid.NewGuid().ToString(),
                    SchoolId = school.Id,
                    Name = "201",
                    TypeDay = TypeDay.Morning,
                    Dirección=""
                }
                ,
                new Grade()
                {
                    Id = Guid.NewGuid().ToString(),
                    SchoolId = school.Id,
                    Name = "301",
                    TypeDay = TypeDay.Afternoon,
                    Dirección=""
                }
                ,
                new Grade()
                {
                    Id = Guid.NewGuid().ToString(),
                    SchoolId = school.Id,
                    Name = "401",
                    TypeDay = TypeDay.Afternoon,
                    Dirección=""
                }
                ,
                new Grade()
                {
                    Id = Guid.NewGuid().ToString(),
                    SchoolId = school.Id,
                    Name = "501",
                    TypeDay = TypeDay.Evening,
                    Dirección=""
                }
            };
        }

        private List<Student> RandomStudentGenerator(Grade grade, int q)
        {
            string[] name1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] lastName = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] name2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var studentList = from n1 in name1
                               from n2 in name2
                               from ln in lastName
                               select new Student
                               {
                                    GradeId = grade.Id,
                                    Name = $"{n1} {n2} {ln}",
                                    Id = Guid.NewGuid().ToString()
                                };

            return studentList.OrderBy((al) => al.Id).Take(q).ToList();
        }
    }
}