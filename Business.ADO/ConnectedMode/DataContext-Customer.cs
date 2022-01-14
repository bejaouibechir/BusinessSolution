using Business.ADO.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Business.ADO.ConnectedMode
{
    public partial class ConnectedDataContext
    {
        public void AddCustomer(Customer customer)
        {
            try
            {

                _requête = "INSERT INTO [dbo].[Customer] ([PersonID],[StoreID],[TerritoryID] ,[ModifiedDate])" +
                            $" VALUES({ customer.PersonId} ,{ customer.StoreId} ,{ customer.TerritoryId}" +
                            $" ,{ customer.ModifiedDate})";
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
        
        public Customer GetCustomer(int id)
        {
            Customer current = new Customer();
            _requête = $"SELECT [CustomerID] ,[PersonID] ,[StoreID] ,[TerritoryID]" +
                $" ,[ModifiedDate] FROM [dbo].[Customer] WHERE CustomerID={id} ";
            try
            {
                _sqlConnection.Open();
                _sqlCommand = new SqlCommand(_requête, _sqlConnection);
                _reader = _sqlCommand.ExecuteReader();//Curseur
                while (_reader.Read())
                {
                    current.CustomerId = int.Parse(_reader[0].ToString());
                    current.PersonId = int.Parse(_reader[1].ToString());
                    current.StoreId = int.Parse(_reader[2].ToString());
                    current.TerritoryId = int.Parse(_reader[3].ToString());
                    current.ModifiedDate = DateTime.Parse(_reader[4].ToString());
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

        public List<Customer> GetAllCustomers()
        {
            List<Customer> all_Customers = new List<Customer>();
            Customer current;
            _requête = " ";
            try
            {
                _sqlConnection.Open();
                _sqlCommand = new SqlCommand(_requête, _sqlConnection);
                _reader = _sqlCommand.ExecuteReader();
                while (_reader.Read())
                {
                    current = new Customer();
                    current.CustomerId = int.Parse(_reader[0].ToString());
                    current.PersonId = int.Parse(_reader[1].ToString());
                    current.StoreId = int.Parse(_reader[2].ToString());
                    current.TerritoryId = int.Parse(_reader[3].ToString());
                    current.ModifiedDate = DateTime.Parse(_reader[4].ToString());
                    all_Customers.Add(current);
                }
                return all_Customers;
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

        public void UpdateCustomer(int id, Customer new_customer)
        {
            Customer current = GetCustomer(id);
            try
            {
                if (current != null)
                {
                    _requête = "UPDATE [dbo].[Customer] SET [PersonID] = {new_customer.PersonId} " +
                             $",[StoreID] = { new_customer.StoreId} ,[TerritoryID] = { new_customer.TerritoryId}" +
                            $" ,[ModifiedDate] = { new_customer.ModifiedDate}" +
                            $"  WHERE [CustomerID] = { id}";
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
        public void DeleteCustomer(int id)
        {
            Customer current = GetCustomer(id);
            try
            {
                if (current != null)
                {
                    _requête = $"DELETE [dbo].[Customer]  WHERE [CustomerId] = {id}";
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
