using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Utilities
{
    public class JsonSerializer<T>
    {     
        /// <summary>
        /// Method to serialize data to json.
        /// </summary>
        /// <param name="values">Input - A list of T type values.</param>
        /// <param name="filename">Input - The name of the file.</param>
        public void SerializeJson(List<T> values, string filename) 
        {
            string jsonString = JsonConvert.SerializeObject(values);
            File.WriteAllText(filename, jsonString);
        }
        /// <summary>
        /// Method to deserialize a json file to data.
        /// </summary>
        /// <param name="filename">Input - The name of the file to be deserialized.</param>
        /// <returns>Returns a list of T type values.</returns>
        public List<T> DeSerializeJson(string filename)
        {   
            string jsonString = File.ReadAllText(filename);
            List<T> values = JsonConvert.DeserializeObject<List<T>>(jsonString);

            return values;
        }
        public List<T> DeSerializeJson(string filename, JsonConverter jsonConverter)
        {
            string jsonString = File.ReadAllText(filename);
            
            List<T> values =  JsonConvert.DeserializeObject<List<T>>(jsonString, jsonConverter);
            
            return values;
        }

    }
}
