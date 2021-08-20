using DomainLayer.Common;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ConfigureBaseEntity();
            builder.Property(m => m.Name).IsRequired().HasMaxLength(150);
            builder.Property(m => m.Surname).IsRequired().HasMaxLength(150);
            builder.Property(m => m.Address).IsRequired().HasMaxLength(500);

            builder.ToTable("Employees");
        }
    }
}
