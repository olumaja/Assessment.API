using Assessment.Core.DTOs;
using Assessment.Core.Interfaces;
using Assessment.Data.Context;
using Assessment.Data.Models;
using Assessment.Infastructure.Helpers;
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

        public PagedList<Student> GetAllStudent(QueryParameters queryParameters)
        {

            var AllStudentCourses = PagedList<Student>.Paginated(
                    _context.Students
                    .Include(x => x.StudentCourses)
                    .ThenInclude(x => x.Course), queryParameters.PageNumber, queryParameters.PageSize
                );

            return AllStudentCourses;
        }
    }
}
