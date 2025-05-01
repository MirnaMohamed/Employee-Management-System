using AutoMapper;
using Employee_Management_System.Context;
using Employee_Management_System.DTOs;
using Employee_Management_System.Entities;

namespace Employee_Management_System.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            DataContext context = new DataContext();
            CreateMap<Employee, DisplayEmployeeDTO>();
            CreateMap<AddEmployeeDTO, Employee>()
                .ReverseMap();
        }
    }
}
