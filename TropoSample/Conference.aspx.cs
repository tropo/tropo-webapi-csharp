using System;
using TropoCSharp.Tropo;
using System.IO;

namespace TropoSamples
{
    public partial class Conference : System.Web.UI.Page
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

                // Create a new Session object and pass in the JSON submitted from Tropo.
                Session tropoSession = new Session(sessionJSON);
                
                // Create a new instance of the Tropo object.
                Tropo tropo = new Tropo();

                // Call an outbound number and create a conference.
                tropo.Call(tropoSession.Parameters["callToNumber"]);
                tropo.Say("Welcome to the conference.");
                tropo.Conference(tropoSession.Parameters["conferenceID"], false, "testConference", false, true, "#");
                tropo.Say("Thanks for joining our conference. Goodbye.");
                tropo.Hangup();

                // Render the JSON for Tropo to consume.
                Response.Write(tropo.RenderJSON());
            }
        }
    }
}
