using Microsoft.EntityFrameworkCore;
using Student_System.Models;
using StudentSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_System.Data
{
    public class StudentSystemContext : DbContext
    {
        StudentSystemContext(DbContextOptions<StudentSystemContext> options)
            : base(options)
        {
        }


        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<HomeworkSubmissions> Homeworks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
