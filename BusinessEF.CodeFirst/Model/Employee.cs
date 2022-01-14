using System;

namespace BusinessEF.CodeFirst.Model
{
    public class Employee :Person
    {
        public Decimal Salary { get; set; }

        public DateTime? HireDate { get; set; }

        /*Propriété de naviguation*/
        public Departement CurrentDepartement { get; set; }
    }
}
