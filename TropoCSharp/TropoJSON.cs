using System.Web;
using Newtonsoft.Json;

namespace TropoCSharp.Tropo
{
    /// <summary>
    /// A utility class to render a Tropo object as JSON.
    /// </summary>
    public static class TropoJSONExtensions
    {
        public static string RenderJSON(this Tropo tropo)
        {
            tropo.Language = null;
            tropo.Voice = null;
            JsonSerializerSettings settings = new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore };
            return JsonConvert.SerializeObject(tropo, Formatting.None, settings).Replace("\\", "").Replace("\"{", "{").Replace("}\"", "}");
        }
    }

}