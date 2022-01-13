using System;
using Business.ADO.Data;
using Business.ADO.DisConnectedMode;

namespace Business.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DisConnectedDataContext context = new DisConnectedDataContext();
            Departement finance = context.GetDepartement(1);
            System.Console.Read();
        }
    }
}



/* ** Ajout de département
 
  ConnectedDataContext context = new ConnectedDataContext();
            Departement prod = new Departement
            {
                GroupName = "Général",
                Name = "Production",
                ModifiedDate = DateTime.Now
            };
            context.AddDepartement(prod);
            Departement marketing = new Departement
            {
                GroupName = "Général",
                Name = "Marketing",
                ModifiedDate = DateTime.Now
            };
            Departement personnel = new Departement
            {
                GroupName = "Général",
                Name = "Personnels",
                ModifiedDate = DateTime.Now
            };
            context.AddDepartement(prod);
            context.AddDepartement(marketing);
            context.AddDepartement(personnel);

            System.Console.WriteLine("Is DONE");
            System.Console.Read();
 
 ** Recuperation de dépratement
 ConnectedDataContext context = new ConnectedDataContext();
            Departement finance = context.GetDepartement(1);

** Recuperation de plusieurs départements
   var departements = context.GetAllDepartements();
 
 */
