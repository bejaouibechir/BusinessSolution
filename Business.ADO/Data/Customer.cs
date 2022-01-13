using System;

namespace Business.ADO.Data
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public int PersonId { get; set; }
        public int StoreId { get; set; }
        public int TerritoryId { get; set; }
        public DateTime? ModifiedDate { get; set; } = DateTime.Now;

        /*Une propriété de navigation */
        public Employee EmployeeInCharge { get; set; }
        public Store PreferredStore { get; set; }
    }
}
