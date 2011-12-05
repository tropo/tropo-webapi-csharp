using System;
using System.Diagnostics;
using System.IO;
using System.Web.UI;
using Newtonsoft.Json;
using TropoCSharp.Tropo;

namespace TropoSamples
{
    /// <summary>
    /// An example script that receives a Tropo Session create POST and returns JSON for sending an outbound message.
    /// Note - use in conjnction withe the TropoOutboundSMS example application.
    /// For further information, see http://blog.tropo.com/2011/04/14/sending-outbound-sms-with-c/
    /// </summary>
    public partial class OutboundSMS : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (StreamReader reader = new StreamReader(Request.InputStream))
            {
                // Get the JSON submitted from Tropo.
                string sessionJSON = TropoUtilities.parseJSON(reader);

                // Create a new instance of the Tropo object.
                Tropo tropo = new Tropo();
                
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
                    tropo.Say("An error occured in the application. Bad JSON");

                }

                catch (Exception ex)
                {
                    EventLog log = new EventLog();
                    log.Source = "TROPOWEBAPI";
                    log.WriteEntry("Tropo WebAPI Exception " + ex.Message, EventLogEntryType.Error);
                    Response.StatusCode = 500;
                    tropo.Say("An error occured in the application.");
                }

                finally
                {
                    Response.Write(tropo.RenderJSON());
                }
            }
        }
    }
}
