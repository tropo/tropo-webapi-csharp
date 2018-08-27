using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using TropoCSharp.Tropo;
using TropoCSharp.Structs;

namespace TropoSamples
{
	/// <summary>
	/// A simple example showing how to say Hello World to a user.
	/// </summary>
    public partial class MessageTest : Page
	{
		public void Page_Load (object sender, EventArgs args)
		{

            using (StreamReader reader = new StreamReader(Request.InputStream))
            {


                // Create a new instance of the Tropo object.
                Tropo tropo = new Tropo();
                
                // Get the JSON submitted from Tropo.
                string sessionJSON = TropoUtilities.parseJSON(reader);

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
                    week[1] = "this is MessageTest这是第二行";
                    week[2] = "https://www.travelchinaguide.com/images/photogallery/2012/beijing-tiananmen-tower.jpg";
                    week[3] = "Today is 13 Aug";
                    //week[3] = "https://me888dia.giphy.com/media/LHZyixOnHwDDy/giphy.gif";

                    List<String> to = new List<String>(1);
                    to.Add(numberToDial);
                    to.Add("14084654399");

                    string currenT = DateTime.Now.ToString("yyyy/MM/dd HH:MM tt");
                    Say say = new Say();
                    say.Value = "this is MMS test for webapi Csharp SDk sent @ " + currenT;
                    say.Media = week;

                    Message message = new Message();
                    message.To = to;
                    message.From = sendFromNumber;
                    message.Network = Network.MMS;
                    message.Say = say;
                    message.PromptLogSecurity = "suppress";
                    message.Voice = "en-us";

                    tropo.Message(message);


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
