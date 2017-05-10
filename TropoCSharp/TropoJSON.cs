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
        public static string JSONToText(this Tropo tropo)
        {
            tropo.Language = null;
            tropo.Voice = null;
            JsonSerializerSettings settings = new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore };
            return JsonConvert.SerializeObject(tropo, Formatting.None, settings).Replace("\\", "").Replace("\"{", "{").Replace("}\"", "}");
        }


        public static void RenderJSON(this Tropo tropo, HttpResponse response)
        {
            tropo.Language = null;
            tropo.Voice = null;
            JsonSerializerSettings settings = new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore };
            //return JsonConvert.SerializeObject(tropo, Formatting.None, settings).Replace("\\", "").Replace("\"{", "{").Replace("}\"", "}");
            Version v = GetVersion();
            // {Major}.{Minor}.{Build}.{Revision}
            int Major = v.Major;
            int Minor = v.Minor;
            int Build = v.Build;
            int Revision = v.Revision;
            //response.AddHeader("WebAPI-Lang-Ver", "webapi_CSharp" + v.ToString());
            response.AddHeader("WebAPI-Lang-Ver", "CSharp V15.7.0 2017-05-12");
            response.Write(JsonConvert.SerializeObject(tropo, Formatting.None, settings).Replace("\\", "").Replace("\"{", "{").Replace("}\"", "}"));

        }

        public static Version GetVersion()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Reflection.AssemblyName assemblyName = assembly.GetName();
            Version version = assemblyName.Version;
            return version;
        }

    }

}