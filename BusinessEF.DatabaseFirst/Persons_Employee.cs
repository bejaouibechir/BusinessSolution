//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessEF.DatabaseFirst
{
    using System;
    using System.Collections.Generic;
    
    public partial class Persons_Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Persons_Employee()
        {
            this.Customers = new HashSet<Customer>();
            this.Departements = new HashSet<Departement>();
        }
    
        public string NationalIDNumber { get; set; }
        public string LoginID { get; set; }
        public string JobTitle { get; set; }
        public System.DateTime BirthDate { get; set; }
        public string MartialStatus { get; set; }
        public string Gender { get; set; }
        public System.DateTime HireDate { get; set; }
        public int VacationHours { get; set; }
        public int SickLeaveHours { get; set; }
        public int BusinessEntityID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual Person Person { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Departement> Departements { get; set; }
    }
}