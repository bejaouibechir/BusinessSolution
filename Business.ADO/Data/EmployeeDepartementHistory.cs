using System;
namespace Business.ADO.Data
{
    public class EmployeeDepartementHistory
    {
        public int BusinessEntityID { get; set; }
        public int DepartementID { get; set; }
        public DateTime? ModifiedDate { get; set; } = DateTime.Now;
        public string Note { get; set; }

        /*Propiété de naviguation*/

        public Departement CurrentDepartement { get; set; }

        public Employee CurrentEmployee { get; set; }

    }
}
