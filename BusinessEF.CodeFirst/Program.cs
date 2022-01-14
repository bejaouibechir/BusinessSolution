using System;
using BusinessEF.CodeFirst.Model;

namespace BusinessEF.CodeFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BusinessContext context = new BusinessContext();
            var finance = new Departement
            {
                DepartementID = 1,
                Name = "Finance",
            };

            context.Departements.Add(finance);
            context.SaveChanges();
        }
    }
}
