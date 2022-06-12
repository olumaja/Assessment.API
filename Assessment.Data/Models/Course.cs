using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Data.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage ="Maximum of characters allow")]
        public string CourseName { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
    }
}
