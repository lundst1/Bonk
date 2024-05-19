using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class TextSerializer
    {
        /// <summary>
        /// Method that serialises a list of strings to a textfile.
        /// </summary>
        /// <param name="filename">Input - The name of the file.</param>
        /// <param name="rows">Input - a List<string> containing data to be written to file.</param>
        public void SerializeText(string filename, List<string> rows)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (string row in rows)
                {
                    writer.WriteLine(row);
                }
            }
        }
        /// <summary>
        /// Method that deserialises a textfile to data.
        /// Reads the file to a List<String>.
        /// </summary>
        /// <param name="filename">Input - The name of the file.</param>
        /// <returns>Returns a List<String>, where a row in the list correspons to a row in the file.</returns>
        public List<string> DeSerializeText(string filename)
        {
            
            List<string> rows = new List<string>();
            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string row = reader.ReadLine();
                    rows.Add(row);
                }
            }
            return rows;
        }
       
    }
}
