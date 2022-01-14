using BusinessEF.CodeFirst.Model;
using System.Data.Entity.ModelConfiguration;

namespace BusinessEF.CodeFirst
{
    public class DepartementConfig : EntityTypeConfiguration<Departement>
    {
        public DepartementConfig()
        {
            HasKey(d => d.DepartementID);
            Property(d => d.Name).IsRequired().HasMaxLength(20);

            ToTable("Departements");
        }
    }
}