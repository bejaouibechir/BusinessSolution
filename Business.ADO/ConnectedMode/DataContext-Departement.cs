using Business.ADO.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
//Data Source=PC2022\SQL;Initial Catalog=AdventureWorksLT;Integrated Security=True
namespace Business.ADO.ConnectedMode
{
    public partial  class ConnectedDataContext
    {
        SqlConnection _sqlConnection;
        string _connectionString;
        string _requête;
        SqlCommand _sqlCommand;
        //En cas de lecture on aura besoin de SqlDataReader
        SqlDataReader _reader;

        public ConnectedDataContext()
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

        public Departement GetDepartement(int id)//Read
        {
            Departement current = new Departement();
            _requête = "SELECT [DepartmentID],[Name],[GroupName],[ModifiedDate]" +
            $"FROM[dbo].[Department] WHERE [DepartmentID] = {id}";

            try
            {
                _sqlConnection.Open();
                _sqlCommand = new SqlCommand(_requête, _sqlConnection);
                _reader = _sqlCommand.ExecuteReader();//Curseur
                while (_reader.Read())
                {
                    current.DepartementID = int.Parse(_reader[0].ToString());
                    current.Name = _reader[1].ToString();
                    current.GroupName = _reader[2].ToString();
                    current.ModifiedDate = DateTime.Parse(_reader[3].ToString());
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                _sqlConnection.Close();
            }


            return current;
        }
        public List<Departement> GetAllDepartements()//Read
        {
            List<Departement> all_departements = new List<Departement>();
            Departement current;
            _requête = " SELECT DepartmentID,Name,GroupName,ModifiedDate " +
                       $" FROM dbo.Department ";
            try
            {
                _sqlConnection.Open();
                _sqlCommand = new SqlCommand(_requête, _sqlConnection);
                _reader = _sqlCommand.ExecuteReader();
                while (_reader.Read())
                {
                    current = new Departement();
                    current.DepartementID = int.Parse(_reader[0].ToString());
                    current.Name = _reader[1].ToString();
                    current.GroupName = _reader[2].ToString();
                    current.ModifiedDate = DateTime.Parse(_reader[3].ToString());
                    all_departements.Add(current);
                }
                return all_departements;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public void UpdateDepartement(int id,Departement new_deparement)//Update
        {
            Departement current = GetDepartement(id);
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
