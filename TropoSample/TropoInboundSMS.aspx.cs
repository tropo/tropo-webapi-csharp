using System;
using System.IO;
using Newtonsoft.Json;
using TropoCSharp.Tropo;
using System.Web.UI;
using TropoCSharp.Structs;
using System.Web;
using System.Xml;
using System.Collections.Generic;

namespace TropoSamples
{
    /// <summary>
    /// A simple example showing how to access properties of the Session object.
    /// </summary>
    public partial class TropoInboundSMS : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (StreamReader reader = new StreamReader(Request.InputStream))
            {
                // Get the JSON submitted from Tropo.
                string sessionJSON = TropoUtilities.parseJSON(reader);

                // Create a new instance of the Tropo class.
                Tropo tropo = new Tropo();

                // Create a new Session object and pass in the JSON submitted from Tropo.
                Session tropoSession = new Session(sessionJSON);
                string smsReceived = tropoSession.InitialText;

                // yu can do your business logic with smsReceived....
                //....
                //....

                // Create an XML doc to hold the response from the Tropo Session API.
                XmlDocument doc = new XmlDocument();
                string token = "6c48697670656858594b62704c62715358444e5a72744a794156715872656a66627a72464b7158626d58374";  // the app's voice token (app's url is SMSBusineessLogic.aspx)
                // A collection to hold the parameters we want to send to the Tropo Session API.
                IDictionary<string, string> parameters = new Dictionary<String, String>();

                parameters.Add("numberToDial", "+8613466549249");
                parameters.Add("textMessageBody", smsReceived);

                // Inintialized another application, here I just say the smsReceived to numberToDial
                doc.Load(tropo.CreateSession(token, parameters));
            }
        }
    }
}
