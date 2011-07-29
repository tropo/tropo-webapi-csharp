using System;
using System.Collections.Generic;
using System.Xml;
using TropoCSharp.Tropo;
using System.Threading;

namespace TropoConference
{
    class Program
    {
        static void Main(string[] args)
        {
            string token = "your-voice-token-goes-here";
            string conferenceID = "my-test-conference";

            // An array of numbers to call and join to the conference.
            string[] numbersToCall = new string[] { "13034567890", "13034567891" };

            // SIP endpoint for a simple Tropo JavaScript app to play a message to the conference. See README file
            string conferenceTimer = "sip:9991480669@sip.tropo.com";

            // the length of time to wait before playing the conference message.
            int timer = 60000;
            
            // A collection to hold the parameters we want to send to the Tropo Session API.
            IDictionary<string, string> parameters = new Dictionary<String, String>();

            // Instantiate a new instance of the Tropo object.
            Tropo tropo = new Tropo();

            // Create an XML doc to hold the response from the Tropo Session API.
            XmlDocument doc = new XmlDocument();

            // Add the conferencce ID to the paramters collection.
            parameters.Add("conferenceID", conferenceID);

            foreach (string number in numbersToCall)
            {
                // Add the number to call to the parameters collection.
                parameters.Add("callToNumber", number);

                // Make API call.
                Console.WriteLine("Sending API request for: " + number);
                doc.Load(tropo.CreateSession(token, parameters));
                Console.WriteLine("Result: " + doc.SelectSingleNode("session/success").InnerText.ToUpper());
                Console.WriteLine("Token: " + doc.SelectSingleNode("session/token").InnerText);
                Console.WriteLine("=============================");

                // Remove the callToNumber key so we can reset in next loop.
                parameters.Remove("callToNumber");                
            }

            // Sleep for x seconds.
            Thread.Sleep(timer);

            // Send reminder message to the conference.
            Console.WriteLine("Sending conference time reminder.");
            parameters.Add("callToNumber", conferenceTimer);
            doc.Load(tropo.CreateSession(token, parameters));
            Console.WriteLine("Result: " + doc.SelectSingleNode("session/success").InnerText.ToUpper());
            Console.WriteLine("Token: " + doc.SelectSingleNode("session/token").InnerText);
            Console.WriteLine("=============================");

            Console.Read();
        }
    }
}
