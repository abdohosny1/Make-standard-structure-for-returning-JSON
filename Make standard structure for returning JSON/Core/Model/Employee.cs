namespace Make_standard_structure_for_returning_JSON.Model
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }


        public int DepartmentId { get; set; }
        public Department Departments { get; set; }
    }
}
