﻿using Assessment.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Core.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<StudentDTO>> GetAllStudentAsync();
    }
}
