using System;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using TropoCSharp.Tropo;

namespace TropoSamples
{
    public partial class OutboundSMS : System.Web.UI.Page
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

                    // Get parameters submitted with Session API call.
                    string sendToNumber = tropoSession.Parameters.Get("sendToNumber");
                    string sendFromNumber = tropoSession.Parameters.Get("sendFromNumber");
                    string channel = tropoSession.Parameters.Get("channel");
                    string network = tropoSession.Parameters.Get("network");
                    string msg = tropoSession.Parameters.Get("msg");

                    // Create a new instance of the Tropo object.
                    Tropo tropo = new Tropo();

                    // Send an outbound message.
                    tropo.Call(sendToNumber, sendFromNumber, network, channel, true, 60, null, null);
                    tropo.Say(msg);

                    // Render the JSON for Tropo to consume.
                    Response.Write(tropo.RenderJSON());

                }

                catch (JsonReaderException ex)
                {
                    EventLog log = new EventLog();
                    log.Source = "TROPOWEBAPI";
                    log.WriteEntry("Tropo WebAPI Exception " + ex.Message, EventLogEntryType.Error);
                    Response.StatusCode = 500;
                    Response.Write("An error occured in the application. Bad JSON");

                }

                catch (Exception ex)
                {
                    EventLog log = new EventLog();
                    log.Source = "TROPOWEBAPI";
                    log.WriteEntry("Tropo WebAPI Exception " + ex.Message, EventLogEntryType.Error);
                    Response.StatusCode = 500;
                    Response.Write("An error occured in the application.");
                }
            }
        }
    }
}
