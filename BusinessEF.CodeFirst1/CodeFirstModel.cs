using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BusinessEF.CodeFirst1
{
    public partial class CodeFirstModel : DbContext
    {
        public CodeFirstModel()
            : base("name=CodeFirstModel")
        {
        }
        /*Les entités*/
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Persons_Employee> Persons_Employee { get; set; }

        /*Cofiguration du model*/
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasOptional(e => e.Persons_Employee)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Persons_Employee>()
                .HasMany(e => e.Customers)
                .WithRequired(e => e.Persons_Employee)
                .HasForeignKey(e => e.EmployeeBusinessEntityID)
                .WillCascadeOnDelete(false);
        }
    }
}
