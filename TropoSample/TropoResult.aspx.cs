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
    public partial class TropoResult : System.Web.UI.Page
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
                string resultJSON = GetJSON(sr);

                try
                {
                    // Create a new Result object and pass in the JSON submitted from Tropo.
                    Result tropoResult = new Result(resultJSON);

                    // A simple example showing how to access properties of the Result object.
                    Response.Write("State:  " + tropoResult.State + "\n");
                    Response.Write("Sequence:  " + tropoResult.Sequence + "\n");
                    Response.Write("SessionId:  " + tropoResult.SessionId + "\n");
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
