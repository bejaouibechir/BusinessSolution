using BusinessEF.CodeFirst.Model;
using System.Data.Entity.ModelConfiguration;

namespace BusinessEF.CodeFirst
{
    public class EmployeeConfig : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfig()
        {
            Property(e => e.Salary).IsRequired();
            HasRequired(e => e.CurrentDepartement)
                .WithMany(d => d.Employees);

            ToTable("Employees");
        }
    }
}