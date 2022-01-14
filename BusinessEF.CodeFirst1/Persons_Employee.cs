namespace BusinessEF.CodeFirst1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Persons_Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Persons_Employee()
        {
            Customers = new HashSet<Customer>();
        }

        [Required]
        public string NationalIDNumber { get; set; }

        [Required]
        public string LoginID { get; set; }

        [Required]
        public string JobTitle { get; set; }

        public DateTime BirthDate { get; set; }

        [Required]
        public string MartialStatus { get; set; }

        [Required]
        public string Gender { get; set; }

        public DateTime HireDate { get; set; }

        public int VacationHours { get; set; }

        public int SickLeaveHours { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BusinessEntityID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers { get; set; }

        public virtual Person Person { get; set; }
    }
}
