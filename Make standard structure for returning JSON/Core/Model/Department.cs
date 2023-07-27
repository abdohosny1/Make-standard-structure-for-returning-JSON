namespace Make_standard_structure_for_returning_JSON.Model
{
    public class Department
    {
        public Department()
        {
            Employees = new List<Employee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public List<Employee> Employees { get; set; }
    }
}