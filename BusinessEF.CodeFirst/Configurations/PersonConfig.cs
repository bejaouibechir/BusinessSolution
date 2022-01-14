using BusinessEF.CodeFirst.Model;
using System.Data.Entity.ModelConfiguration;

namespace BusinessEF.CodeFirst
{
    public class PersonConfig : EntityTypeConfiguration<Person>
    {
        public PersonConfig()
        {
           /*Fluent API*/
            HasKey(p => p.BusinessEntityID);
            Property(p => p.FirstName).IsRequired().HasMaxLength(50);
            Property(p => p.LastName).IsRequired().HasMaxLength(50);
            Property(p => p.Age).IsRequired();
            ToTable("Persons");
        }
    }
}