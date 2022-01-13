using Business.ADO.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Business.ADO.DisConnectedMode
{
    public partial class DisConnectedDataContext
    {

        public void AddEmployee(Employee employee)
        {
            //Ajouter la logique d'inserer un employee dans la base 
        }

        public Employee GetEmployee(int id)
        {
            Employee employee = new Employee();
            //Ajouter la logique pour recuperer l'employee de la base

            return employee;
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            //Ajouter la logique pour peupler la liste 
            return employees;
        }

        public void UpdateEmployee(int id,Employee new_employee)
        {
            Employee current = GetEmployee(id);

            try
            {
                if (current != null)
                {
                    //Ajouter la logique de mise à jour de l'employee
                }
                else
                {
                    throw new ArgumentException("L'entrée qui correpend à l'id n'est pas trouvable dans la table employee");
                }
            }
            catch (ArgumentException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        public void DeleteEmployee(int id)
        {
            Employee current = GetEmployee(id);

            try
            {
                if (current != null)
                {
                    //Ajouter la logique de suppression de l'employee
                }
                else
                {
                    throw new ArgumentException("L'entrée qui correpend à l'id n'est pas trouvable dans la table employee");
                }
            }
            catch (ArgumentException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

    }
}
