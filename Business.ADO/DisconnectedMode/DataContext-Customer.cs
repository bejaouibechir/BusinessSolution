using Business.ADO.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Business.ADO.DisConnectedMode
{
    public partial class DisConnectedDataContext
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
                _adapter.Fill(_dataTable);
                var raw = _dataTable.Rows[0];
                current.CustomerId = int.Parse(raw[0].ToString());
                current.PersonId = int.Parse(raw[1].ToString());
                current.TerritoryId = int.Parse(raw[2].ToString());
                current.ModifiedDate = DateTime.Parse(raw[3].ToString());
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

        public DataTable GetAllCustomers()
        {
            DataTable all_customers = new DataTable();
         
            _requête = "SELECT[CustomerID] ,[PersonID] ,[StoreID] ,[TerritoryID]" +
                $" ,[ModifiedDate] FROM [dbo].[Customer] "; 
            try
            {
                _sqlConnection.Open();
                _sqlCommand = new SqlCommand(_requête, _sqlConnection);
                _adapter = new SqlDataAdapter(_sqlCommand);
                _adapter.Fill(all_customers);
                return all_customers;
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
