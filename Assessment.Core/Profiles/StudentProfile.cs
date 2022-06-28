using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assessment.Core.DTOs;
using Assessment.Data.Models;
using AutoMapper;

namespace Assessment.Core.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDTO>().ReverseMap();
        }
    }
}
