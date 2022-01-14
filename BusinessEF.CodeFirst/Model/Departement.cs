using System.Collections.Generic;

namespace BusinessEF.CodeFirst.Model
{
    public class Departement
    {

        public Departement()
        {
            Employees = new List<Employee>();
        }

        public int DepartementID { get; set; }
        public string Name { get; set; }

        /*Proppriété de naviguation*/
        public List<Employee> Employees { get; set; }
    }
}
