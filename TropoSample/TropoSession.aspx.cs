using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using TropoCSharp.Tropo;
using Newtonsoft.Json;

namespace TropoSamples
{
    public partial class TropoSession : System.Web.UI.Page
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

                    // A simple example showing how to access properties of the Session object.
                    Response.Write("ID:  " + tropoSession.Id + "\n");
                    Response.Write("To-Channel: " + tropoSession.To.channel+ "\n");
                    Response.Write("From-Channel: " + tropoSession.From.channel+ "\n");
                    Response.Write("Initial Text: " + tropoSession.InitialText + "\n");
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
