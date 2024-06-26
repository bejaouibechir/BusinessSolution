﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Business.JSON
{
    public partial class DataContext<T>
    {
        public void Add(T entity)
        {
            JsonSerializer serializer  = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;

            using (StreamWriter sw = new StreamWriter($@"D:\AdventureWorks\{entity.GetHashCode()}.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, entity);
                // {"ExpiryDate":new Date(1230375600000),"Price":0}
            }
        }
        public void Update(int id,T new_entity)
        {
            T current;
            JsonSerializer serializer = new JsonSerializer();
            using (StreamReader sw = new StreamReader($@"D:\AdventureWorks\{id}.json"))
            using (JsonTextReader reader = new JsonTextReader(sw))
            {
                current = (T)serializer.Deserialize<T>(reader);
                //Mise à jour
                current = new_entity; 
            }
            using (StreamWriter sw = new StreamWriter($@"D:\AdventureWorks\{id}.json"))
            using (JsonTextWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer,current);
            }

        }
        public void Delete(int id)
        {
            File.Delete($@"D:\AdventureWorks\{id}.json");
        }

        public T Get(int id)
        {
            T current;
            JsonSerializer serializer = new JsonSerializer();

            try
            {
                using (StreamReader sw = new StreamReader($@"D:\AdventureWorks\{id}.json"))
                using (JsonTextReader reader = new JsonTextReader(sw))
                {
                    current = (T)serializer.Deserialize<T>(reader);
                    //Mise à jour
                    return current;
                }
            }
            catch (FileNotFoundException ex)
            {
                Debug.WriteLine(ex.Message);
                return default(T);
            }
        }

        public List<T> GetAll()
        {
            List<T> entities = new List<T>();
            int id;
            T current;
            //Ecrire la logique pour récuperer toutes les données de fichiers dans D:\AdventureWorks
            string path;
            foreach (string filePath in Directory.GetFiles(@"D:\AdventureWorks"))
            {
                path = filePath
                    .Replace(@"D:\AdventureWorks\", string.Empty).Replace(".json",string.Empty);
                id = int.Parse(path);
                current = Get(id);
                entities.Add(current);
            }

            return entities;
        }

    }
}
