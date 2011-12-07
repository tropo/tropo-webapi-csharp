using System;
using System.IO;
using System.Web.UI;
using TropoCSharp.Tropo;
using TropoCSharp.Structs;

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
                // Create a new instance of the Tropo object.
                Tropo tropo = new Tropo();

                if (!String.IsNullOrEmpty(Request.QueryString["signal"]))
                {
                    if (Request.QueryString["signal"] == "interruptConference")
                    {
                        tropo.Say(". Now, rejoin the conference. Press the pound key to  exit without hanging up.");
                        tropo.Conference(Request.QueryString["confid"], false, "testConference", false, true, "#");
                        tropo.Say("You have now left the conference.");
                        tropo.Hangup();
                    }
                    else
                    {
                        tropo.Say("The call is now over.  Gooddbye.");
                        tropo.Hangup();
                    }
                }

                else
                {
                    // Get the JSON submitted from Tropo.
                    string sessionJSON = TropoUtilities.parseJSON(reader);

                    // Create a new Session object and pass in the JSON submitted from Tropo.
                    Session tropoSession = new Session(sessionJSON);

                    // Create a signal to end the conference.
                    string[] signals = new string[] { "interruptConference", "endCall" };

                    // Call an outbound number and create a conference.
                    tropo.Call(tropoSession.Parameters["callToNumber"]);
                    tropo.Say("Welcome to the conference.");
                    tropo.Conference(tropoSession.Parameters["conferenceID"], signals, false, "testConference", false, true, "#");
                    tropo.On("interruptConference", "Conference.aspx?signal=interruptConference&confid=" + tropoSession.Parameters["conferenceID"], new Say("You have left the conference."));
                    tropo.On("endCall", "Conference.aspx?signal=endCall", new Say("You have left the conference."));
                }

                // Render the JSON for Tropo to consume.
                Response.Write(tropo.RenderJSON());
            }
        }
    }
}
