using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;
using TropoCSharp.Structs;
using TropoCSharp.Tropo;

namespace TropoSample
{
    public partial class CreateSession : System.Web.UI.Page
    {
        // The token for initiating an outbound message from Tropo.
        // Note - make sure the type of token you are usisng matches the channel/network arguments passed to CreateSession().
        private string token = "enter-your-token-here";

        protected void Page_Load(object sender, EventArgs e)
        {
            IDictionary<string, string> parameters = new Dictionary<String, String>();
            // Enter a phone number here.
            parameters.Add("connectTo", "1112223333"); 
            
            // Select the channel you want to use via the Channel struct.
            parameters.Add("channel", Channel.Voice);

            // Select the network you want to use with the Network struct.
            parameters.Add("network", Network.Pstn); 

            // Message is sent as a query string parameter, make sure it is properly encoded.
            parameters.Add("message", HttpUtility.UrlEncode("This is a test message from C sharp."));

            // Instanntiate a new instance of the Tropo object.
            Tropo tropo = new Tropo();

            // Create an XML doc to hold the response from the Tropo Session API.
            XmlDocument doc = new XmlDocument();

            // Load the XML document with the return vallue of the CreateSession() method call.
            doc.Load(tropo.CreateSession(token, parameters));

            // Assign the relevent return values to 
            SessionResult.Text = doc.SelectSingleNode("session/success").InnerText.ToUpper();
            TokenID.Text = doc.SelectSingleNode("session/token").InnerText;
        }
    }
}
