using Assessment.Core.DTOs;
using Assessment.Data.Models;
using Assessment.Infastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Core.Interfaces
{
    public interface IStudentRepository
    {
        PagedList<Student> GetAllStudent(QueryParameters queryParameters);
    }
}
