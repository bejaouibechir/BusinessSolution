using Business.ADO.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
//Data Source=PC2022\SQL;Initial Catalog=AdventureWorksLT;Integrated Security=True
namespace Business.ADO.DisConnectedMode
{
    public partial class DisConnectedDataContext
    {
        SqlConnection _sqlConnection;
        string _connectionString;
        string _requête;
        SqlCommand _sqlCommand;
        //En cas de lecture on aura besoin de SqlDataReader
        SqlDataAdapter _adapter;
        DataSet _dataSet;

        public DisConnectedDataContext()
        {
            _connectionString = @"Data Source=PC2022\SQL;"+
                 "Initial Catalog=AdventureWorksLT;Integrated Security=True";
            _sqlConnection = new SqlConnection(_connectionString);
        }
       //CRUD: Create Read Update Delete
        #region les opérations crud 

        public void AddDepartement(Departement deparement)//Create
        {
            try
            {
                
                _requête = "INSERT INTO[dbo].[Department]([Name],[GroupName],[ModifiedDate])" +
                                $"VALUES('{deparement.Name}', '{deparement.GroupName}', '{deparement.ModifiedDate}')";
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
        public DataTable GetAllDepartements()//Read
        {
            DataTable current = new DataTable();
            _requête = "SELECT [DepartmentID],[Name],[GroupName],[ModifiedDate]" +
            $"FROM[dbo].[Department] ";

            try
            {
                _sqlConnection.Open();
                _sqlCommand = new SqlCommand(_requête, _sqlConnection);
                _adapter = new SqlDataAdapter(_sqlCommand);
                _dataSet = new DataSet();
                _adapter.Fill(_dataSet);
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                _sqlConnection.Close();
            }
            return _dataSet.Tables[0];
        }
        public void UpdateDepartement(int id,Departement new_deparement)//Update
        {
            var current = GetDepartement(id);
            try
            {
                if (current != null)
                {
                    _requête = "UPDATE [dbo].[Department] " +
                                 $" SET [Name] = '{ new_deparement.Name}' " +
                               $", [GroupName] = '{ new_deparement.GroupName}' " +
                                $", [ModifiedDate] = '{ new_deparement.ModifiedDate}' " +
                                  $" WHERE [DepartmentID] = {id}";
                    _sqlConnection.Open();
                    _sqlCommand = new SqlCommand(_requête, _sqlConnection);
                    _sqlCommand.ExecuteNonQuery();
                }
                else
                {
                    throw new ArgumentException("Le id que vous communiquez ne correpend à" +
                        " aucune entrée dans la table département");
                }
            }
            catch (ArgumentException ex)
            {
                Debug.WriteLine(ex.Message); 
            }
        }

        private object GetDepartement(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteDepartement(int id)//Delete
        {
            Departement current = GetDepartement(id);

            try
            {
                if (current != null)
                {
                    _requête = $"DELETE [dbo].[Department] WHERE [DepartmentID] = {id}";
                    _sqlConnection.Open();
                    _sqlCommand = new SqlCommand(_requête, _sqlConnection);
                    _sqlCommand.ExecuteNonQuery();
                }
                else
                {
                    throw new ArgumentException("Le id que vous communiquez ne correpend à" +
                        " aucune entrée dans la table département");
                }
            }
            catch (ArgumentException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        #endregion

    }
}
