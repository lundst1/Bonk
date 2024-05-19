using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Utilities;

namespace ListManager
{
    public class ListManager<T> : IListManager<T>
    {
        //Private variable for instance of class TextSerializer
        private TextSerializer textSerializer = new TextSerializer();
        //Private variable for instance of class JsonSeriali
        private JsonSerializer<T> jsonSerializer = new JsonSerializer<T>();
        //Private variable for instance of class XMLSerializer.
        private XMLSerializer<T> xmlSerializer = new XMLSerializer<T>();
        //Variable for a List<T>
        List<T> m_List = new List<T>();
        public List<T> List { 
            get { return m_List; } 
            set { m_List = value; }
        }
        /// <summary>
        /// Property that returns the size of the list.
        /// </summary>
        public int Count { get { return m_List.Count; } }
        /// <summary>
        /// Method that adds a T item to the list.
        /// </summary>
        /// <param name="type">A type T item</param>
        /// <returns>Returns true if the item is not null</returns>
        public bool Add(T type)
        {
            bool success = false;

            if (type != null)
            {
                m_List.Add(type);
                success = true;
            }

            return success;
        }
        /// <summary>
        /// Method that updates item in list at given index.
        /// </summary>
        /// <param name="type">An item of type T</param>
        /// <param name="index">An integer that expresses a place in the index of the list.</param>
        /// <returns>Returns true if the integer is within bounds of the index.</returns>
        public bool ChangeAt(T type, int index)
        {
            bool success = false;
            if (CheckIndex(index))
            {
                m_List[index] = type;
                success = true;
            }

            return success;
        }
        /// <summary>
        /// Method that checks that an integer is within bounds of the index.
        /// </summary>
        /// <param name="index">An integer that expresses a place in the index of the list.</param>
        /// <returns>Returns true if the integer is within bounds of the index.</returns>
        public bool CheckIndex(int index)
        {
            bool valid = false;

            if (index >= 0 && index < m_List.Count)
            {
                valid = true;
            }

            return valid;
        }
        /// <summary>
        /// Method that deletes all items in the list. 
        /// </summary>
        public void DeleteAll()
        {
            m_List.Clear();
        }
        /// <summary>
        /// Method that deletes an item at certain index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Returns true if index is within bounds.</returns>
        public bool DeleteAt(int index)
        {
            bool success = false;

            if (CheckIndex(index))
            {
                m_List.RemoveAt(index);
                success = true;
            }

            return success;
        }
        /// <summary>
        /// Method that retrieves item at given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Returns an item of type T.</returns>
        public T GetAt(int index)
        {
            T type = default(T);
            if (CheckIndex(index))
            {
                type = m_List[index];
            }
            return type;
        }
        /// <summary>
        /// Method that returns a string array representation of m_List.
        /// Iterates through the list and calls method ToString on every item and adds them to the array.
        /// </summary>
        /// <returns>Returns a string array of string representations of an item of type T.</returns>
        public string[] ToStringArray() 
        {
            string[] strings = new string[m_List.Count];
            for (int i = 0; i < m_List.Count; i++)
            {
                string strValue = m_List[i].ToString();
                strings[i] = strValue;
            }
            return strings;
        }
        /// <summary>
        /// Method that returns a string list representation of m_List.
        /// Iterates through the list and calls method ToString on every item and adds to the string list.
        /// </summary>
        /// <returns>Returns a string list of string representations of an item of type T</returns>
        public List<string> ToStringList()
        {
            List<String> stringList = new List<string>();
            for (int i = 0;i < m_List.Count;i++)
            {
                string strValue = m_List[i].ToString();
                stringList.Add(strValue);
            }
            return stringList;
        }
        /// <summary>
        /// Method that serializes values to text file.
        /// Calls method SerializeText in class TextSerializer.
        /// Passes values as List<string>.
        /// </summary>
        /// <param name="filename">Input - Name of file that the data is to serialized to.</param>
        public void SerializeText(string filename)
        {
            List<string> values = ToStringList();
            textSerializer.SerializeText(filename, values);
        }
        /// <summary>
        /// Method that deserializes a text file to values.
        /// Calls method DeserializeText in class TextSerializer.
        /// Passes result to method ParseText.
        /// </summary>
        /// <param name="filename">Input - Name of file that the data is to deserialized from.</param>
        public List<string> DeserializeText(string filename)
        {
            List<string> values = textSerializer.DeSerializeText(filename);
            return values;
        }
        public void SerializeJson(string filename)
        {
            jsonSerializer.SerializeJson(m_List, filename);
        }
        /// <summary>
        /// Method to deserialize json to values.
        /// Calls method DeSerializeJson in JsonSerializer.
        /// </summary>
        /// <param name="filename">Input - Name of file that the data is to deserialized from.</param>
        public void DeserializeJson(string filename, JsonConverter jsonConverter)
        {
            m_List = jsonSerializer.DeSerializeJson(filename, jsonConverter);

        }
        /// <summary>
        /// Method to serialize the food items to XML.
        /// Calls method SerializeXML in class XMLSerializer.
        /// Passes food items as a List and the filename.
        /// </summary>
        /// <param name="filename">Input - The name of the file that the data is to be serialized to.</param>
        public void SerializeXML(string filename)
        {
            xmlSerializer.SerializeXML(m_List, filename);
        }
        /// <summary>
        /// Method to deserialize an XML file to food items.
        /// Calls method DeserializeXML in XMLSerializer.
        /// </summary>
        /// <param name="filename">Input - The name of the file that the data is to be deserialized from.</param>
        public void DeserializeXML(string filename)
        {
            m_List = xmlSerializer.DeserializeXML(filename);
        }
    }
}
