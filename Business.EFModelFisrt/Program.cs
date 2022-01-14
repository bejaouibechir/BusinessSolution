using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.EFModelFisrt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BusinessModelContainer context = new BusinessModelContainer();
            Departement finance = new Departement { Name="Finance",
                GroupName="Général", 
                ModifiedDate= new DateTime(2022,1,14)};
            context.Departements.Add(finance);
            //EF implemente Unit Of Work
            context.SaveChanges();
        }
    }
}
