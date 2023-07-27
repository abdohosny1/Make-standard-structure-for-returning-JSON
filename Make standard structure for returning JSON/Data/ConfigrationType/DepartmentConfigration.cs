using Make_standard_structure_for_returning_JSON.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Make_standard_structure_for_returning_JSON.Data.ConfigrationType
{
    public class DepartmentConfigration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(e => e.Name).IsRequired().HasMaxLength(80);
        }
    }
}