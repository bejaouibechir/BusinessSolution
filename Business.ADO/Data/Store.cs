using System.Collections.Generic;

namespace Business.ADO.Data
{
    public class Store
    {
        public Store()
        {
            Customers = new List<Customer>();
        }
        public int SoreId { get; set; }
        public string Name { get; set; }

        public string Country { get; set; }
        public string Region { get; set; }

        /*Propriété de navigation*/
        public List<Customer> Customers { get; set; }
    }
}
