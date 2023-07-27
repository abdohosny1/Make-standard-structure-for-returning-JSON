using Make_standard_structure_for_returning_JSON.Core.Repository;
using Make_standard_structure_for_returning_JSON.Model;

namespace Make_standard_structure_for_returning_JSON.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;
        public IBaseRepository<Employee> Employees { get; private set; }

        public IBaseRepository<Department> Departments { get; private set; }

        public IEmployeeRepository EmployeeRepositoru { get; private set; }

        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;

            Employees = new BaseRepository<Employee>(_context);
            Departments = new BaseRepository<Department>(_context);
            EmployeeRepositoru = new EmployeeRepository(_context);

        }
        public int Complete()
        {
            return _context.SaveChanges();

        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}