using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Student_System.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Unicode]
        [StringLength(80)]
        public string Name { get; set; } = null!;

        [Unicode]
        public string? Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        public ICollection<Student> StudentsEnrolled { get; set; } = new List<Student>();

        public ICollection<Resource> Resources { get; set; } = new List<Resource>();

        public ICollection<HomeworkSubmissions> HomeworkSubmissions { get; set; } = new List<HomeworkSubmissions>();
    }
}