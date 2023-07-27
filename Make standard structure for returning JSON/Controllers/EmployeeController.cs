using AutoMapper;
using Make_standard_structure_for_returning_JSON.Core.Repository;
using Make_standard_structure_for_returning_JSON.Dto;
using Make_standard_structure_for_returning_JSON.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Make_standard_structure_for_returning_JSON.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Employee), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<EmployeeDto>> GetAllEmployee()
        {
            var data = await _unitOfWork.Employees.GellAllAsync(s => s.Departments);

            //var rseult = data.Select(e=>new EmployeeDto()
            //{
            //    Id=e.Id,
            //   Name = e.Name,
            //   Address = e.Address,
            //  DepartmentId = e.DepartmentId,
            //  DepartmentName= e.Departments.Name,
            //});

            var result = _mapper.Map<IReadOnlyList<EmployeeDtoWithName>>(data);

            return Ok(result);
        }

        [HttpGet("name")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeeBYDepartment(string name)
        {
            if (name == null) return BadRequest();
            var data = await _unitOfWork.EmployeeRepositoru.GetAllEmployeeByDepartment(name);
            var result = _mapper.Map<IReadOnlyList<EmployeeDtoWithName>>(data);

            return Ok(result);
        }

        [HttpPost()]
        public async Task<ActionResult<EmployeeDto>> AddEmployee(EmployeeDto employeeDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var emp = new Employee()
            {
                Address = employeeDto.Address,
                DepartmentId = employeeDto.DepartmentId,
                Name = employeeDto.Name
            };
            var item = await _unitOfWork.Employees.AddAsync(emp);
            return Ok(item);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EmployeeDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<EmployeeDto>> GetByID(int id)
        {
            if (id == null) return NotFound($"Not found Id ={id}");

            var item = await _unitOfWork.EmployeeRepositoru.GetEmployeeBYID(id);

            if (item == null)
            {
                return NotFound($"Not found Id ={id}");
            }
            else
            {
                var res = _mapper.Map<EmployeeDtoWithName>(item);
                return Ok(res);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == null) return NotFound($"Not found Id ={id}");

            var item = await _unitOfWork.Employees.GetByIDAsync(id);

            if (item == null)
            {
                return NotFound($"Not found Id ={id}");
            }
            else
            {
                await _unitOfWork.Employees.DeleteAsync(item);
                return NoContent();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> update(int id, EmployeeDto employeeDto)
        {
            if (id == null) return NotFound($"Not found Id ={id}");
            var item = await _unitOfWork.Employees.GetByIDAsync(id);
            if (item == null)
            {
                return NotFound($"Not found Id ={id}");
            }
            else
            {
                item.Address = employeeDto.Address;
                item.Name = employeeDto.Name;
                item.DepartmentId = employeeDto.DepartmentId;

                await _unitOfWork.Employees.UpdateAsync(item);

                return Ok();
            }
        }
    }
}