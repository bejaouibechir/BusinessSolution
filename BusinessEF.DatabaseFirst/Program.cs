using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEF.DatabaseFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BusinessDataBaseFirstEntities context = new BusinessDataBaseFirstEntities();
            var finance = context.Departements.SingleOrDefault(dep => dep.DepartementID == 1);
            var marketing = new Departement
            {
                Name = "Marketing",
                GroupName = "Général",
                ModifiedDate = new DateTime(2022, 1, 14)
            };
            context.Departements.Add(marketing);
            context.SaveChanges();
        }
    }
}
