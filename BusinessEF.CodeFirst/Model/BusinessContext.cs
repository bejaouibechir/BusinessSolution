using System;
using System.Data.Entity;

namespace BusinessEF.CodeFirst.Model
{
    public class BusinessContext :DbContext
    {

        public BusinessContext():base("CodeFirstModel")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<BusinessContext>());
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Departement> Departements { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new PersonConfig());
            modelBuilder.Configurations.Add(new EmployeeConfig());
            modelBuilder.Configurations.Add(new DepartementConfig());

        }

    }
}
