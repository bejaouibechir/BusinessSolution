using System;
namespace Business.JSON.Data
{
    public class EmployeeDepartementHistory
    {
        public int BusinessEntityId { get; set; }
        public int DepartementId { get; set; }
        public DateTime? ModifiedDate { get; set; } = DateTime.Now;
        public string Note { get; set; }

        /*Propiété de naviguation*/

        public Departement CurrentDepartement { get; set; }

        public Employee CurrentEmployee { get; set; }

    }
}
