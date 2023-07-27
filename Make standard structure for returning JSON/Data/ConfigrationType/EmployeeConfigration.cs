using Make_standard_structure_for_returning_JSON.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Make_standard_structure_for_returning_JSON.Data.ConfigrationType
{
    public class EmployeeConfigration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Name).IsRequired().HasMaxLength(80);
            builder.Property(e => e.Address).IsRequired().HasMaxLength(280);
        }
    }
}
