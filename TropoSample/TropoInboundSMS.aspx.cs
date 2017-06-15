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

                // Create an XML doc to hold the response from the Tropo Session API.
                XmlDocument doc = new XmlDocument();
                string token = "584c466166734645667651785355666c7652564c495756676c4c664e786976415655584e6741525155536b6c";
                // A collection to hold the parameters we want to send to the Tropo Session API.
                IDictionary<string, string> parameters = new Dictionary<String, String>();

                // Enter a phone number to send a call or SMS message to here.
                parameters.Add("numberToDial", "+8613466549249");
                parameters.Add("textMessageBody", tropoSession.InitialText);

                doc.Load(tropo.CreateSession(token, parameters));
            }
        }
    }
}
