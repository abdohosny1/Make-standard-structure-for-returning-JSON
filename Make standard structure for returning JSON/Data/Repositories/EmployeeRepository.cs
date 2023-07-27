using Make_standard_structure_for_returning_JSON.Core.Repository;
using Microsoft.EntityFrameworkCore;
using Make_standard_structure_for_returning_JSON.Model;

namespace Make_standard_structure_for_returning_JSON.Data.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDBContext _dBContext;
        public EmployeeRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeeByDepartment(string name)
        {
            var result = await _dBContext.Employees.Where(e => e.Departments.Name == name).Include(e => e.Departments)

                .ToListAsync();

            return result;

        }

        public async Task<Employee> GetEmployeeBYID(int id)
        {
            var result = await _dBContext.Employees.Include(e => e.Departments)
                .FirstOrDefaultAsync(e => e.Id == id);
            return result;
        }
    }
}