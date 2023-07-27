using Make_standard_structure_for_returning_JSON.Model;

namespace Make_standard_structure_for_returning_JSON.Core.Repository
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetAllEmployeeByDepartment(string name);
        Task<Employee> GetEmployeeBYID(int id);
    }
}
