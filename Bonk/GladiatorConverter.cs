using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Bonk.Gladiators;
using Xceed.Wpf.Toolkit;

namespace Bonk
{
    public class GladiatorConverter : JsonConverter
    {
        /// <summary>
        /// Determines whether an instance of an object can convert the specified object type.
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(Gladiator).IsAssignableFrom(objectType);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jsonObject = JObject.Load(reader);
            string gladiator = jsonObject["Gladiator"].ToString();

            switch (gladiator)
            {
                case "0":
                    return jsonObject.ToObject<Mage>();
                case "1":
                    return jsonObject.ToObject<Rouge>();
                case "2":
                    return jsonObject.ToObject<Wizard>();
                default:
                    throw new NotSupportedException($"Gladiator type '{gladiator}' is not supported.");
            }
        }
        /// <summary>
        /// Method that does nothing and is only here to implement JsonConverter. 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        /// <exception cref="NotImplementedException"></exception>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
