using System;
using System.Collections.Generic;

namespace Business.ADO.Data
{
    public class Employee :Person
    {
        public Employee()
        {
            Customers = new List<Customer>();
            Histories = new List<EmployeeDepartementHistory>();
        }
        
        public string NationalIDNumber { get; set; }
        public string LoginID { get; set; }
        public string JobTitle { get; set; }
        public DateTime? BirthDate { get; set; }
        public char MaritalStatus { get; set; }
        public char Gender { get; set; }
        public DateTime? HireDate { get; set; }
        public short VacationHours { get; set; }
        public short SickLeaveHours { get; set; }

        /*Porpriété de navigation*/
        public List<Customer> Customers { get; set; }

        public List<EmployeeDepartementHistory> Histories { get; set; }


    }
}
