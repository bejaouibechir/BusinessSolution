using System;
using System.Collections.Generic;

namespace Business.JSON.Data
{
    public class Departement
    {
        public Departement()
        {
            Histories = new List<EmployeeDepartementHistory>();
        }

        public int DepartementID { get; set; }
        public string Name { get; set; }

        public string GroupName { get; set; }
        public DateTime ModifiedDate { get; set; }

        /*Propriétés de navigation*/
        public List<EmployeeDepartementHistory> Histories { get; set; }
    }
}
