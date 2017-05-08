using System;
using System.IO;
using Newtonsoft.Json;
using TropoCSharp.Tropo;
using System.Web.UI;
using System.Collections.Generic;
using System.Net;

namespace TropoSamples
{
    /// <summary>
    /// A simple example showing how to access properties of the Session object.
    /// </summary>
    public partial class TropoSession : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            WebHeaderCollection myWebHeaderCollection = (WebHeaderCollection)Request.Headers;

            string[] headers = myWebHeaderCollection.AllKeys;

            // enumerate through the header collection.
            foreach (string s in headers)
            {
                Console.WriteLine("Header {0}, value {1}",s,myWebHeaderCollection.Get(s));
            }

            //HttpContext.Current.Trace.Warn(DateTime.Now.ToString() + " xiaoxishi is" + xiaoxishi);

            using (StreamReader reader = new StreamReader(Request.InputStream))
            {
                // Get the JSON submitted from Tropo.
                string sessionJSON = TropoUtilities.parseJSON(reader);

                // Create a new instance of the Tropo class.
                Tropo tropo = new Tropo();

                try
                {
                    // Create a new Session object and pass in the JSON submitted from Tropo.
                    Session tropoSession = new Session(sessionJSON);
                    foreach (string s in headers)
                    {
                        Console.WriteLine("Header {0}, value {1}", s, myWebHeaderCollection.Get(s));
                        tropo.Say("Header  is" + s + "  value is " + myWebHeaderCollection.Get(s));
                    }
                    tropo.Say("The Tropo Session ID is " + tropoSession.Id);
                    tropo.Say("The channnel of the called party is " + tropoSession.To.Channel);
                    tropo.Say("The channel of the calling party is " + tropoSession.From.Channel);
                    tropo.Say("This initial text sent with the call is " + tropoSession.InitialText);
                    tropo.Say("The From SIP header on the call is " + TropoUtilities.removeQuotes(tropoSession.Headers["From"]));
                }

                catch (JsonReaderException)
                {
                    tropo.Say("Sorry, an error occured. I choked on some JSON");
                }

                catch (Exception ex)
                {
                    tropo.Say("Sorry, an error occured. " + ex.Message);
                }

                finally
                {
                    Response.Write(tropo.RenderJSON());
                }
            }
        }
    }
}
