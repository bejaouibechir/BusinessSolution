namespace BusinessEF.CodeFirst1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Customer
    {
        public int CustomerID { get; set; }

        public int PersonID { get; set; }

        public int StoreID { get; set; }

        public int TerritoryID { get; set; }

        public DateTime ModifiedDate { get; set; }

        public int EmployeeBusinessEntityID { get; set; }

        public int StoreStoreID { get; set; }

        public virtual Persons_Employee Persons_Employee { get; set; }
    }
}
