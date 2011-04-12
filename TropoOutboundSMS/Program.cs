using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;
using TropoCSharp.Structs;
using TropoCSharp.Tropo;

namespace OutboundTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // The voice and messaging tokens provisioned when your Tropo application is set up.
            string voiceToken = "00401f421ee41645ac281ba49b6eebcba6f5dabb1d5e022ee71041b1517ae8c562d612a89f2658d5ab72f670";
            string messagingToken = "004046ba101ab14ea91826d1ec0034195c27974f23397c1aca7bb463f5b77aca2fc56ac136a1ed1d08ca04bc";

            // A collection to hold the parameters we want to send to the Tropo Session API.
            IDictionary<string, string> parameters = new Dictionary<String, String>();

            // Enter a phone number to send a call or SMS message to here.
            parameters.Add("sendToNumber", "13025888258");

            // Enter a phone number to use as the caller ID.
            parameters.Add("sendFromNumber", "15853260554");

            // Select the channel you want to use via the Channel struct.
            string channel = Channel.Text;
            parameters.Add("channel", channel);

            string network = Network.SMS;
            parameters.Add("network", network);

            // Message is sent as a query string parameter, make sure it is properly encoded.
            parameters.Add("msg", HttpUtility.UrlEncode("This is a test message from C#."));

            // Instantiate a new instance of the Tropo object.
            Tropo tropo = new Tropo();

            // Create an XML doc to hold the response from the Tropo Session API.
            XmlDocument doc = new XmlDocument();

            // Set the token to use.
            string token = channel == Channel.Text ? messagingToken : voiceToken;

            // Load the XML document with the return value of the CreateSession() method call.
            doc.Load(tropo.CreateSession(token, parameters));

            // Display the results in the console.
            Console.WriteLine("Result: " + doc.SelectSingleNode("session/success").InnerText.ToUpper());
            Console.WriteLine("Token: " + doc.SelectSingleNode("session/token").InnerText);
            Console.Read();
        }
    }
}
