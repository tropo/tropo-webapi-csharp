using System;
using System.IO;
using System.Web.UI;
using TropoCSharp.Tropo;

namespace TropoSamples
{
    /// <summary>
    /// A simple example demonstrating how to place an outbound call and create a conference.
    /// </summary>
    public partial class Conference : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (StreamReader reader = new StreamReader(Request.InputStream))
            {
                // Get the JSON submitted from Tropo.
                string sessionJSON = TropoUtilities.parseJSON(reader);

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
