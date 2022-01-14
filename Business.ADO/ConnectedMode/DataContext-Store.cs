using Business.ADO.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Business.ADO.ConnectedMode
{
    public partial class ConnectedDataContext
    {
        public void AddStore(Store store)
        {
            try
            {

                _requête = "INSERT INTO [dbo].[Store] ([Name],[Country],[City],[Region])"+
                            $"VALUES({ store.Name},{ store.Country},{ store.City},{ store.Region})";
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
        
        public Store GetStore(int id)
        {
            Store current = new Store();
            _requête = $"SELECT [StoreId],[Name],[Country],[City],[Region] FROM [dbo].[Store] WHERE StoreId={id}";
            try
            {
                _sqlConnection.Open();
                _sqlCommand = new SqlCommand(_requête, _sqlConnection);
                _reader = _sqlCommand.ExecuteReader();//Curseur
                while (_reader.Read())
                {
                    current.SoreId = int.Parse(_reader[0].ToString());
                    current.Name = _reader[1].ToString();
                    current.Country = _reader[2].ToString();
                    current.City = _reader[3].ToString();
                    current.Region = _reader[4].ToString();
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

        public List<Store> GetAllStores()
        {
            List<Store> all_stores = new List<Store>();
            Store current;
            _requête = " ";
            try
            {
                _sqlConnection.Open();
                _sqlCommand = new SqlCommand(_requête, _sqlConnection);
                _reader = _sqlCommand.ExecuteReader();
                while (_reader.Read())
                {
                    current = new Store();
                    current.SoreId = int.Parse(_reader[0].ToString());
                    current.Name = _reader[1].ToString();
                    current.Country = _reader[2].ToString();
                    current.City = _reader[3].ToString();
                    current.Region = _reader[4].ToString();
                    all_stores.Add(current);
                }
                return all_stores;
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

        public void UpdateStore(int id, Store new_store)
        {
            Store current = GetStore(id);
            try
            {
                if (current != null)
                {
                    _requête = "UPDATE [dbo].[Store] SET [Name] = {new_store.Name} " +
                                 $", [Country] = { new_store.Country} ,[City] = { new_store.City} " +
                                  $",[Region] = { new_store.Region} " +
                    $" WHERE [StoreId] = {id}";
  
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
        public void DeleteStore(int id)
        {
            Store current = GetStore(id);
            try
            {
                if (current != null)
                {
                    _requête = $"DELETE [dbo].[Store]  WHERE [StoreId] = {id}";
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
