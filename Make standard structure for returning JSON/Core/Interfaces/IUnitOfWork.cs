using Make_standard_structure_for_returning_JSON.Model;

namespace Make_standard_structure_for_returning_JSON.Core.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Employee> Employees { get; }
        IBaseRepository<Department> Departments { get; }
        IEmployeeRepository EmployeeRepositoru { get; }

        int Complete();

    }
}