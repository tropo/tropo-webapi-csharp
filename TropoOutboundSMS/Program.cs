using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;
using TropoCSharp.Structs;
using TropoCSharp.Tropo;

namespace OutboundTest
{
    /// <summary>
    /// A simple console appplication used to launch a Tropo Session and send an outbound SMS.
    /// Note - use in conjnction withe the OutboundSMS.aspx example in the TropoSamples project.
    /// For further information, see http://blog.tropo.com/2011/04/14/sending-outbound-sms-with-c/
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // The voice and messaging tokens provisioned when your Tropo application is set up.
            string voiceToken = "your-voice-token-here";
            string messagingToken = "your-messaging-token-here";

            // A collection to hold the parameters we want to send to the Tropo Session API.
            IDictionary<string, string> parameters = new Dictionary<String, String>();

            // Enter a phone number to send a call or SMS message to here.
            parameters.Add("numberToDial", "15551112222");

            // Enter a phone number to use as the caller ID.
            parameters.Add("sendFromNumber", "15551113333");

            // Select the channel you want to use via the Channel struct.
            string channel = Channel.Text;
            parameters.Add("channel", channel);

            string network = Network.SMS;
            parameters.Add("network", network);

            // Message is sent as a query string parameter, make sure it is properly encoded.
            parameters.Add("textMessageBody", HttpUtility.UrlEncode("This is a test message from C#."));

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
