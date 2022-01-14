using Business.ADO.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Business.ADO.ConnectedMode
{
    public partial class ConnectedDataContext
    {
        public void AddEmployeeDepartementHistory(EmployeeDepartementHistory employeeDepartementHistory)
        {
            try
            {

                _requête = "INSERT INTO [dbo].[EmployeeDepartmentHistory]" +
           "([BusinessEntityID],[DepartmentID],[ModifiedDate],[Note])" +
                   " VALUES" +
                   $"({employeeDepartementHistory.BusinessEntityId} " +
                   $" ,{employeeDepartementHistory.DepartementId} " +
                   $" ,{employeeDepartementHistory.ModifiedDate} " +
                    $" ,{employeeDepartementHistory.Note} ";
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
        
        public EmployeeDepartementHistory GetEmployeeDepartementHistory(int id)
        {
            EmployeeDepartementHistory current = new EmployeeDepartementHistory();
            _requête = $"SELECT [BusinessEntityID],[DepartmentID],[ModifiedDate] ,[Note] " +
                $" FROM [dbo].[EmployeeDepartmentHistory] WHERE BusinessEntityID={id} ";
            try
            {
                _sqlConnection.Open();
                _sqlCommand = new SqlCommand(_requête, _sqlConnection);
                _reader = _sqlCommand.ExecuteReader();//Curseur
                while (_reader.Read())
                {
                    current = new EmployeeDepartementHistory();
                    current.BusinessEntityId = int.Parse(_reader[0].ToString());
                    current.DepartementId = int.Parse(_reader[1].ToString());
                    current.ModifiedDate = DateTime.Parse(_reader[2].ToString());
                    current.Note = _reader[3].ToString();
                }
                return current;
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

        public List<EmployeeDepartementHistory> GetAllEmployeeDepartementHistorys()
        {
            List<EmployeeDepartementHistory> all_EmployeeDepartementHistorys = new List<EmployeeDepartementHistory>();
            EmployeeDepartementHistory current;
            _requête = " ";
            try
            {
                _sqlConnection.Open();
                _sqlCommand = new SqlCommand(_requête, _sqlConnection);
                _reader = _sqlCommand.ExecuteReader();
                while (_reader.Read())
                {
                    current = new EmployeeDepartementHistory();
                    current.BusinessEntityId = int.Parse(_reader[0].ToString());
                    current.DepartementId = int.Parse(_reader[1].ToString());
                    current.ModifiedDate = DateTime.Parse(_reader[2].ToString());
                    current.Note = _reader[3].ToString();

                    all_EmployeeDepartementHistorys.Add(current);
                }
                return all_EmployeeDepartementHistorys;
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

        public void UpdateEmployeeDepartementHistory(int id, EmployeeDepartementHistory new_EmployeeDepartementHistory)
        {
            EmployeeDepartementHistory current = GetEmployeeDepartementHistory(id);
            try
            {
                if (current != null)
                {
                    _requête = "UPDATE [dbo].[EmployeeDepartmentHistory] " +
                               $" SET [BusinessEntityID] = {new_EmployeeDepartementHistory.BusinessEntityId}" +
                                $" ,[DepartmentID] = {new_EmployeeDepartementHistory.DepartementId}" +
                                $" ,[ModifiedDate] = {new_EmployeeDepartementHistory.ModifiedDate}" +
                                $" ,[Note] = {new_EmployeeDepartementHistory.Note}" +
                               $" WHERE [BusinessEntityID]={id}";
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
        public void DeleteEmployeeDepartementHistory(int id)
        {
            EmployeeDepartementHistory current = GetEmployeeDepartementHistory(id);
            try
            {
                if (current != null)
                {
                    _requête = $"DELETE [dbo].[EmployeeDepartementHistory]  WHERE [EmployeeDepartementHistoryId] = {id}";
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

    }
}
