//#define ado
#define json
using System;

namespace Business.Console
{
#if ado
    using Business.DAL.Abstraction;
    using Business.DAL.ImplAdoSqlServer;
    using Business.ADO.Data;
#endif
#if json
    using Business.DAL.Abstraction;
    using Business.DAL.ImplJson;
    using Business.JSON.Data;
#endif


    internal class Program
    {
        static void Main(string[] args)
        {
            IRepository<Departement> repository = new DepartementRepository();
            Departement general = new Departement
            {
                Name = "DG",
                GroupName = "Général", ModifiedDate = new DateTime(2022, 1, 14)
            };
            repository.Add(general);
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

** Recuperation d'un ensemble de lignes avec le mode déconnecté
DisConnectedDataContext context = new DisConnectedDataContext();
            DataTable all_departements = context.GetAllDepartements();

            List<Departement> deprartement_list = new List<Departement>();
            Departement current;
            foreach (DataRow r in all_departements.Rows)
            {     //On va peupler la liste
                    current = new Departement();
                current.DepartementID = int.Parse(r[0].ToString());
                current.Name = r[1].ToString();
                current.GroupName = r[2].ToString();
                current.ModifiedDate = DateTime.Parse(r[3].ToString());
                deprartement_list.Add(current);
            }

** Ajouter un employee

 ConnectedDataContext context = new ConnectedDataContext();
            Employee employee = new Employee
            {
                --La partie Person de l'employee
BusinessEntityID = 1,
                PersonType = "Mr",
                Title = "Doctor",
                FirstName = "Machin",
                LastName = "Machin",
                EmailPromotion = 1,
                ModifiedDate = new DateTime(2022, 1, 14),

                --La partie employée
                NationalIDNumber = "FR-M03",
                LoginID = "machin",
                JobTitle = "Directeur",
                BirthDate = new DateTime(1955, 11, 4),
                MaritalStatus = 'M',
                Gender = 'M',
                HireDate = new DateTime(2005, 2, 14),
                VacationHours = 20,
                SickLeaveHours = 0

            };
context.AddEmployee(employee);


*/
