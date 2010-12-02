using System;
using System.IO;
using Newtonsoft.Json;
using TropoCSharp.Tropo;

namespace TropoSample
{
    public partial class TropoSessionCreate : System.Web.UI.Page
    {
        // A helper method to get the JSON submitted from Tropo.
        private string GetJSON(StreamReader reader)
        {
            return reader.ReadToEnd();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader(Request.InputStream))
            {
                // Get the JSON submitted from Tropo.
                string sessionJSON = GetJSON(sr);

                try
                {
                    // Create a new Session object and pass in the JSON submitted from Tropo.
                    Session tropoSession = new Session(sessionJSON);

                    // A simple example showing how to access parameters on the Session object.
                    Response.Write("Parameters-Action:  " + tropoSession.Parameters["action"]);
                }

                catch (JsonReaderException ex)
                {
                    Response.Write("An error occured. " + ex.Message);
                }

                catch (Exception ex)
                {
                    Response.Write("An error occured. " + ex.Message);
                }
            }
        }
    }
}
