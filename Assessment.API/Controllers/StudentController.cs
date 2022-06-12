using Assessment.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        public async Task<IActionResult> GetStudents()
        {
            try
            {
                var students = await _studentRepository.GetAllStudentAsync();

                if(students == null)
                {
                    return BadRequest("Users don't exist");
                }

                return Ok(students);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Something went wrong");
            }
            
        }
    }
}
