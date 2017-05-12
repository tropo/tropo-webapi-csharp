using System;
using System.IO;
using Newtonsoft.Json;
using TropoCSharp.Tropo;
using System.Web.UI;
using System.Web;

namespace TropoSamples
{
    /// <summary>
    /// A simple example showing how to access properties of the Session object.
    /// </summary>
    public partial class TropoReject : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

                    //tropo.Say("The Tropo Session ID is " + tropoSession.Id);
                    //tropo.Say("The channnel of the called party is " + tropoSession.To.Channel);
                    //tropo.Say("The channel of the calling party is " + tropoSession.From.Channel);
                    //tropo.Say("This initial text sent with the call is " + tropoSession.InitialText);
                    //tropo.Say("The From SIP header on the call is " + TropoUtilities.removeQuotes(tropoSession.Headers["From"]));

                    
                    string fromName = tropoSession.From.Name;
                    string fromChannel = tropoSession.From.Channel;
                    string toName = tropoSession.To.Name;
                    string toE164Id = tropoSession.To.E164Id;
                    string fromE164Id = tropoSession.From.E164Id;

                    string accountId = tropoSession.AccountId;
                    string callId = tropoSession.CallId;

                    tropo.Say("from Name is " + fromName);
                    tropo.Say("to E164 Id is " + toE164Id);
                    tropo.Say("fro mE164Id is " + fromE164Id);

                    tropo.Say("account Id is " + accountId);
                    tropo.Say("call Id is " + callId);


                    if (fromName.Contains("xiang"))
                    {
                        tropo.Say("Welcome frank");
                        tropo.Say("Just beep beep beep");
                    }
                    else
                    {
                        // tropo.Say("Sorry Alex");
                        HttpContext.Current.Trace.Warn(fromName + " You had been rejected cruely ");
                        tropo.Reject();
                    }
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
                    tropo.RenderJSON(Response);
                    //HttpContext.Current.Trace.Warn("tropo.JSONToTe666666xt() is" + tropo.JSONToText());
                    //Response.Write("{\"tropo\":[{ \"reject\":null}]}");
                }
            }
        }
    }
}
