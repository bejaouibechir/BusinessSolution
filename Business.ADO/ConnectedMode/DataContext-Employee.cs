using Business.ADO.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Business.ADO.ConnectedMode
{
    public partial class ConnectedDataContext
    {
        public void AddEmployee(Employee employee)
        {
            try
            {
                _requête =  /*Partie emplyee*/
                " INSERT INTO [dbo].[Employee] ([BusinessEntityID] ,[NationalIDNumber] ,[LoginID],[JobTitle] " +
                           " ,[BirthDate],[MaritalStatus],[Gender],[HireDate],[VacationHours] ,[SickLeaveHours],[ModifiedDate]) " +
                     $" VALUES ({employee.BusinessEntityID} " +
                         $"  ,'{employee.NationalIDNumber}' " +
                         $"  , '{employee.LoginID}' " +
                         $"  ,'{employee.JobTitle}' " +
                        $"  ,'{employee.BirthDate}' " +
                         $" ,'{employee.MaritalStatus}' " +
                         $" ,'{employee.Gender}' " +
                         $"  ,'{employee.HireDate}' " +
                         $"  ,{employee.VacationHours} " +
                         $"  ,{employee.SickLeaveHours} " +
                         $"  ,'{employee.ModifiedDate}') " +
                /*Partie Personne*/
                "INSERT INTO [dbo].[Person] ([BusinessEntityID] ,[PersonType] " +
                "     ,[Title] ,[FirstName]  ,[MiddleName] ,[LastName] ,[EmailPromotion],[ModifiedDate]) " +
                $"	  VALUES  ({employee.BusinessEntityID} " +
                $"   ,'{employee.PersonType}' " +
                $"  ,'{employee.Title}' " +
                $"  ,'{employee.FirstName}' " +
                $"  ,'{employee.MiddleName}' " +
                $"  ,'{employee.LastName}' " +
                $" ,{employee.EmailPromotion} " +
                $",'{employee.ModifiedDate}') ";
               
                _sqlConnection.Open();
                _sqlCommand = new SqlCommand(_requête, _sqlConnection);
                _sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                _sqlConnection.Close();
            }
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
