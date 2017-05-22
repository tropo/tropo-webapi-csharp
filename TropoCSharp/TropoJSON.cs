using System.Web;
using Newtonsoft.Json;
using System;

namespace TropoCSharp.Tropo
{
    /// <summary>
    /// A utility class to render a Tropo object as JSON.
    /// </summary>
    public static class TropoJSONExtensions
    {
        public static void RenderJSON(this Tropo tropo, HttpResponse response)
        {
            tropo.Language = null;
            tropo.Voice = null;
            JsonSerializerSettings settings = new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore };
            response.AddHeader("WebAPI-Lang-Ver", "CSharp V15.9.0 SNAPSHOT");
            response.Write(JsonConvert.SerializeObject(tropo, Formatting.None, settings).Replace("\\", "").Replace("\"{", "{").Replace("}\"", "}"));

        }
    }

}