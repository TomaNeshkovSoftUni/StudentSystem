using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_System.Data;
using Student_System.Models;

namespace Student_System
{
    internal class Startup
    {
        public static void Main(string[] args)
        {
            StudentSystemContext context = new StudentSystemContext();

            ListAllStudentsWithTheirRegisteredDateAndNumberOfCourses(context);

            ListAllCoursesWithTotalNumberOfResources(context);

            ListCourseResourcesAndStudentEnrollments(context);

            ListStudentsByCourseCount(context);

            ShowCoursesWithLateSubmissions(context);

        }
        public static void ListAllStudentsWithTheirRegisteredDateAndNumberOfCourses(StudentSystemContext context)
        {
            var studentsWithCourseCount = context.Students
                .Select(s => new
                {
                    StudentName = s.Name,
                    RegisteredOn = s.RegisteredOn.ToShortDateString(),
                    CoursesCount = s.CourseEnrollments.Count,
                    Courses = s.CourseEnrollments
                        .Select(c => c.Name)
                        .ToList()
                })
                .OrderByDescending(s => s.CoursesCount)
                .ToList();

            foreach (var s in studentsWithCourseCount)
            {
                Console.WriteLine($"Student: {s.StudentName}");
                Console.WriteLine($"Registered: {s.RegisteredOn}");
                Console.WriteLine($"Courses Enrolled: {s.CoursesCount}");
                Console.WriteLine("Courses: " + string.Join(", ", s.Courses));
                Console.WriteLine();
            }

        }

        public static void ListAllCoursesWithTotalNumberOfResources(StudentSystemContext context)
        {
            var coursesWithResourceCount = context.Courses
                .Select(c => new
                {
                    c.CourseId,
                    c.Name,
                    ResourcesCount = c.Resources.Count
                })
                .ToList();

            Console.WriteLine("Courses with Resource Count:");
            foreach (var c in coursesWithResourceCount)
            {
                Console.WriteLine($"ID: {c.CourseId}, Name: {c.Name}, Resources: {c.ResourcesCount}");
            }
            Console.WriteLine();

            var studentsByCourseCount = context.Students
                .Select(s => new
                {
                    s.StudentId,
                    FullName = s.Name,
                    CoursesCount = s.CourseEnrollments.Count
                })
                .OrderByDescending(s => s.CoursesCount)
                .ThenBy(s => s.FullName)
                .ToList();

            Console.WriteLine("Students by Course Count:");
            foreach (var s in studentsByCourseCount)
            {
                Console.WriteLine($"ID: {s.StudentId}, Name: {s.FullName}, Courses: {s.CoursesCount}");
            }
        }

        public static void ListCourseResourcesAndStudentEnrollments(StudentSystemContext context)
        {
            var coursesWithResourceCount = context.Courses
                .Select(c => new
                {
                    c.CourseId,
                    c.Name,
                    ResourcesCount = c.Resources.Count
                })
                .ToList();

            Console.WriteLine("Courses with Resource Count:");
            foreach (var c in coursesWithResourceCount)
            {
                Console.WriteLine($"ID: {c.CourseId}, Name: {c.Name}, Resources: {c.ResourcesCount}");
            }
            Console.WriteLine();

            var studentsByCourseCount = context.Students
                .Select(s => new
                {
                    s.StudentId,
                    FullName = s.Name,
                    CoursesCount = s.CourseEnrollments.Count
                })
                .OrderByDescending(s => s.CoursesCount)
                .ThenBy(s => s.FullName)
                .ToList();

            Console.WriteLine("Students by Course Count:");
            foreach (var s in studentsByCourseCount)
            {
                Console.WriteLine($"ID: {s.StudentId}, Name: {s.FullName}, Courses: {s.CoursesCount}");
            }
        }

        public static void ListStudentsByCourseCount(StudentSystemContext context)
        {
            var studentsByCourseCount = context.Students
                .Select(s => new
                {
                    s.StudentId,
                    FullName = s.Name,
                    CoursesCount = s.CourseEnrollments.Count
                })
                .OrderByDescending(s => s.CoursesCount)
                .ThenBy(s => s.FullName)
                .ToList();

            Console.WriteLine("Students Ordered by Course Enrollment Count:");
            foreach (var s in studentsByCourseCount)
            {
                Console.WriteLine($"ID: {s.StudentId}, Name: {s.FullName}, Courses Enrolled: {s.CoursesCount}");
            }
        }

        public static void ShowCoursesWithLateSubmissions(StudentSystemContext context)
        {
            var lateSubmissionCourses = context.Courses
                .Where(c => c.HomeworkSubmissions
                    .Any(h => h.SubmissionTime > c.EndDate)
                )
                .Select(c => new
                {
                    c.CourseId,
                    c.Name,
                    c.EndDate
                })
                .ToList();

            Console.WriteLine("Courses with Late Homework Submissions:");
            foreach (var course in lateSubmissionCourses)
            {
                Console.WriteLine($"ID: {course.CourseId}, Course: {course.Name}, Ended On: {course.EndDate.ToShortDateString()}");
            }
        }
    }
}