using Assessment.Core.DTOs;
using Assessment.Core.Interfaces;
using Assessment.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Core.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<StudentDTO>> GetAllStudentAsync()
        {
            var AllStudentCourses = await _context.Students.Include(x => x.StudentCourses).ThenInclude(x => x.Course).ToListAsync();

            var students = AllStudentCourses.Select(x => new StudentDTO
            {
                Id = x.Id,
                Name = x.Name,
                TheStudentCourses = x.StudentCourses.Select(c => new CourseDTO
                {
                    Id = c.Course.Id,
                    CourseName = c.Course.CourseName
                }).ToList()
            }).ToList();

            return students;
        }
    }
}
