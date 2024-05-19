using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Utilities
{
    public class XMLSerializer<T>
    {   
        //Private variable for instance of XMLSerializer.
        private XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
        /// <summary>
        /// Method to serialize data to XML.
        /// </summary>
        /// <param name="list">Input - A list of T type values.</param>
        /// <param name="filename">The name of the file to be serialized.</param>
        public void SerializeXML(List<T> list, string filename)
        {
            XmlSerializer serialiser = new XmlSerializer(typeof(List<T>));

            using (StreamWriter writer = new StreamWriter(filename))
            {
                serialiser.Serialize(writer, list);
            }
        }
        /// <summary>
        /// Method to deserialize an XML file to data.
        /// </summary>
        /// <param name="filename">Input - The name of the file to be serialized.</param>
        /// <returns>Returns a list of T type values.</returns>
        public List<T> DeserializeXML(string filename)
        {
            List<T> values = new List<T>();

            using (Stream reader = new FileStream(filename, FileMode.Open))
            {
                values = (List<T>)serializer.Deserialize(reader);
                reader.Close();
            }
            return values;
            
        }
    }
}
