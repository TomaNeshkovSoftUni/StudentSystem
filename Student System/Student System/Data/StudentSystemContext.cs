using Microsoft.EntityFrameworkCore;
using Student_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_System.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<HomeworkSubmissions> Homeworks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(students =>
            {

                students.HasMany(s => s.CourseEnrollments)
                        .WithMany(c => c.StudentsEnrolled);

                students.Property(s => s.PhoneNumber)
                        .IsFixedLength();

                students.HasData(
                    new Student
                    {
                        StudentId = 1,
                        Name = "Damian Georgiev",
                        PhoneNumber = "1234567890",
                        RegisteredOn = new DateTime(2024, 10, 15),
                        Birthday = new DateTime(2000, 5, 20)
                    },

                    new Student
                    {
                        StudentId = 2,
                        Name = "Hristo Panayotov",
                        PhoneNumber = "0987654321",
                        RegisteredOn = new DateTime(2024, 10, 15),
                        Birthday = new DateTime(2000, 5, 20)
                    },

                    new Student
                    {
                        StudentId = 3,
                        Name = "Stefan Apostolov",
                        PhoneNumber = "1324354657",
                        RegisteredOn = new DateTime(2024, 10, 15),
                        Birthday = new DateTime(2000, 5, 20)
                    },

                    new Student
                    {
                        StudentId = 4,
                        Name = "Viktor Simeonov",
                        PhoneNumber = "19283746",
                        RegisteredOn = new DateTime(2024, 10, 15),
                        Birthday = new DateTime(2000, 5, 20)
                    },

                    new Student
                    {
                        StudentId = 5,
                        Name = "Orlin Rizov",
                        PhoneNumber = "56473829",
                        RegisteredOn = new DateTime(2024, 10, 15),
                        Birthday = new DateTime(2000, 5, 20)
                    }
                );
            });

            modelBuilder.Entity<Course>(courses =>
            {
                courses.HasData(
                    new Course
                    {
                        CourseId = 1,
                        Name = "Programming Basics",
                        Description = "Intro to programming with C#",
                        StartDate = new DateTime(2025, 01, 10),
                        EndDate = new DateTime(2025, 03, 10),
                        Price = 120m
                    },
                    new Course
                    {
                        CourseId = 2,
                        Name = "Databases",
                        Description = "Work with SQL and EF Core",
                        StartDate = new DateTime(2025, 02, 01),
                        EndDate = new DateTime(2025, 04, 01),
                        Price = 200m
                    },
                    new Course
                    {
                        CourseId = 3,
                        Name = "JavaScript Advanced",
                        Description = "DOM, AJAX and SPA basics",
                        StartDate = new DateTime(2025, 03, 05),
                        EndDate = new DateTime(2025, 05, 05),
                        Price = 180m
                    },
                    new Course
                    {
                        CourseId = 4,
                        Name = "Algorithms and Data Structures",
                        Description = "Sorting, searching, graphs",
                        StartDate = new DateTime(2025, 04, 15),
                        EndDate = new DateTime(2025, 06, 15),
                        Price = 250m
                    }
                );
            });

            modelBuilder.Entity<Resource>(builder =>
            {
                builder.HasData(
                    new Resource
                    {
                        ResourceId = 1,
                        Name = "C# Slides",
                        Url = "http://example.com/csharp/slides",
                        ResourceType = ResourceType.Presentation,
                        CourseId = 1
                    },
                    new Resource
                    {
                        ResourceId = 2,
                        Name = "C# Video Intro",
                        Url = "http://example.com/csharp/video",
                        ResourceType = ResourceType.Video,
                        CourseId = 1
                    },
                    new Resource
                    {
                        ResourceId = 3,
                        Name = "C# Svetlin Nakov Course",
                        Url = "http://example.com/csharp/video",
                        ResourceType = ResourceType.Document,
                        CourseId = 1
                    }
                );
            });

            modelBuilder.Entity<HomeworkSubmissions>(homeworkSubmissions =>
            {
                homeworkSubmissions.HasData(
                    new HomeworkSubmissions
                    {
                        HomeworkId = 1,
                        Content = "submissions/alice_hw1.zip",
                        ContentType = ContentType.Zip,
                        SubmissionTime = new DateTime(2024, 11, 15),
                        StudentId = 1,
                        CourseId = 1
                    },
                    new HomeworkSubmissions
                    {
                        HomeworkId = 2,
                        Content = "submissions/boris_hw1.pdf",
                        ContentType = ContentType.Pdf,
                        SubmissionTime = new DateTime(2024, 12, 2),
                        StudentId = 2,
                        CourseId = 1
                    },
                    new HomeworkSubmissions
                    {
                        HomeworkId = 3,
                        Content = "submissions/vera_hw_db.docx",
                        ContentType = ContentType.Application,
                        SubmissionTime = new DateTime(2024, 11, 28),
                        StudentId = 3,
                        CourseId = 2
                    },
                    new HomeworkSubmissions
                    {
                        HomeworkId = 4,
                        Content = "submissions/dimitar_hw_web.zip",
                        ContentType = ContentType.Zip,
                        SubmissionTime = new DateTime(2025, 2, 1),
                        StudentId = 4,
                        CourseId = 3
                    }
                );
            });
        }
    }
}