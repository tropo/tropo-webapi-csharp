using System.IO;
using Newtonsoft.Json.Linq;
using System.Text;

namespace TropoCSharp.Tropo
{
    /// <summary>
    /// Utility class for Tropo WebAPI.
    /// </summary>
    public static class TropoUtilities
    {
        /// <summary>
        /// Method to read JSON sent from Tropo WebAPI.
        /// </summary>
        /// <param name="reader">Streamreader representing the JSON sent from Tropo.</param>
        /// <returns>String of JSON</returns>
        public static string parseJSON(StreamReader reader)
        {
            return reader.ReadToEnd();
        }

        /// <summary>
        /// Parse a child object that is part of a Tropo JSON payload.
        /// </summary>
        /// <param name="tropoObject"></param>
        /// <returns></returns>
        public static JObject parseObject(JContainer tropoObject)
        {
            return JObject.Parse(tropoObject.ToString());
        }
        
        /// <summary>
        /// Parse the child Actions object that is part of the Tropo Result object. 
        /// </summary>
        /// <param name="actions">Actions - is either an Object or an Array.</param>
        /// <returns></returns>
        public static JContainer parseActions(JContainer actions)
        {
            JTokenType type = actions.Type;
            if (type == JTokenType.Array)
            {
                return JArray.Parse(actions.ToString());
            }
            else
            {
                return parseObject(actions);
            }
        }

        /// <summary>
        /// Remove double quotes from strings that can break JSON.
        /// </summary>
        /// <param name="value">The string to remove double quotes from.</param>
        /// <returns></returns>
        public static string removeQuotes(string value) 
        {
            return value.Replace("\"", "");
        }

        /// <summary>
        /// Add spaces to a string of digits  to improve TTS readback.
        /// </summary>
        /// <param name="value">The string to add spaces to.</param>
        /// <returns></returns>
        public static string addSpaces(string value)
        {
            StringBuilder str = new StringBuilder();
            char[] array = value.ToCharArray();
            foreach(char s in array) 
            {
                str.Append(s + " ");
            }
            return str.ToString();
        }
    }
}
