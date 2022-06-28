using Assessment.Core.DTOs;
using Assessment.Core.Interfaces;
using Assessment.Infastructure.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentRepository _studentRepository;

        public StudentController(ILogger<StudentController> logger, IStudentRepository studentRepository)
        {
            _logger = logger;
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public IActionResult GetStudents([FromQuery] QueryParameters queryParameters)
        {
            try
            {
                var students = _studentRepository.GetAllStudent(queryParameters);

                if(students == null)
                {
                    return BadRequest("Users don't exist");
                }

                var meta = new
                {
                    students.CurrentPage,
                    students.TotalPages,
                    students.PageSize,
                    students.HasNext,
                    students.HasPrevious
                };

                var AllStudentCourses = students.Select(x => new StudentDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    TheStudentCourses = x.StudentCourses.Select(c => new CourseDTO
                    {
                        Id = c.Course.Id,
                        CourseName = c.Course.CourseName
                    }).ToList()
                }).ToList();

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(meta));

                return Ok(AllStudentCourses);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Something went wrong");
            }
            
        }
    }
}
