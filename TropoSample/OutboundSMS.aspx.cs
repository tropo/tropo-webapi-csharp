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
                    string numberToDial = tropoSession.Parameters.Get("numberToDial");
                    //numberToDial = "5093176303";
                    string sendFromNumber = tropoSession.Parameters.Get("sendFromNumber");
                    //sendFromNumber = "14082041999";
                    string channel = tropoSession.Parameters.Get("channel");
                    string network = tropoSession.Parameters.Get("network");
                    string textMessageBody = tropoSession.Parameters.Get("textMessageBody");

                    string[] week = new string[4];
                    week[0] = "http://artifacts.voxeolabs.net.s3.amazonaws.com/test/test.png";
                    week[1] = "this is 这是第二行";
                    week[2] = "https://www.travelchinaguide.com/images/photogallery/2012/beijing-tiananmen-tower.jpg";
                    week[3] = "Today is 13 Aug";
                    //week[3] = "https://me888dia.giphy.com/media/LHZyixOnHwDDy/giphy.gif";


                    string currenT = DateTime.Now.ToString("yyyy/MM/dd HH:MM tt");
                    Say say = new Say();
                    say.Value = "this is MMS test for webapi Csharp SDk sent @ " + currenT;
                    say.Media = week;
                    



                    // Send an outbound message.
                    tropo.Call(numberToDial, sendFromNumber, network, channel, true, 60, null);
                    // tropo.Say(textMessageBody);
                    tropo.Say(say);

                    //tropo.RenderJSON(Response);

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
                    tropo.RenderJSON(Response);
                }
            }
        }
    }
}
