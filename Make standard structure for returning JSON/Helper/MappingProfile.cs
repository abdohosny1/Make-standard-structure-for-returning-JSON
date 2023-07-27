using AutoMapper;
using Make_standard_structure_for_returning_JSON.Dto;
using Make_standard_structure_for_returning_JSON.Model;

namespace Make_standard_structure_for_returning_JSON.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDtoWithName>()
                .ForMember(o => o.DepartmentName, p => p.MapFrom(e => e.Departments.Name))
                .ReverseMap();

            CreateMap<EmployeeDto, Employee>();

            CreateMap<Department, DepartmentDto>();
        }
    }
}