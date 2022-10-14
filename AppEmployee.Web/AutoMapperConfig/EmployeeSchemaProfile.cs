using AppEmployee.Dll.Entities;
using AppEmployee.Web.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppEmployee.Web.AutoMapperConfig
{
    public class EmployeeSchemaProfile: Profile
    {
        public EmployeeSchemaProfile()
        {
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
        }
    }
}
