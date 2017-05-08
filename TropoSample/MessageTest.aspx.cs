using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using TropoCSharp.Structs;
using TropoCSharp.Tropo;

namespace TropoSamples
{
	/// <summary>
	/// A simple example showing how to say Hello World to a user.
	/// </summary>
    public partial class MessageTest : Page
	{
        public void Page_Load(object sender, EventArgs args)
        {
            string xiaoxishi = Request.QueryString["xiaoxi"];
            HttpContext.Current.Trace.Warn(DateTime.Now.ToString() + " xiaoxishi is" + xiaoxishi);


            using (StreamReader reader = new StreamReader(Request.InputStream))
            {

                // Get the JSON submitted from Tropo.
                string sessionJSON = TropoUtilities.parseJSON(reader);
                HttpContext.Current.Trace.Warn(DateTime.Now.ToString() + " sessionJSON is" + sessionJSON);

                string xiaoxi2shi = "dddddddddddd";
                string numberToSMS = "8613466549249";
                if (String.IsNullOrEmpty(sessionJSON))
                {
                    xiaoxi2shi = "kong";
                }else
                {
                    JObject session = JObject.Parse(sessionJSON);
                    xiaoxi2shi = (string)session["session"]["parameters"]["xiaoxi"];
                    numberToSMS = (string)session["session"]["parameters"]["numberToSMS"];
                }
                HttpContext.Current.Trace.Warn(DateTime.Now.ToString() + " xiaoxi444shi is" + xiaoxi2shi);

                // Create a new instance of the Tropo object.
                Tropo tropo = new Tropo();

                // Call the say method of the Tropo object and give it a prompt to say.
                //tropo.Say("Hello World!");

                List<String> to = new List<String>(1);
                to.Add("+" + numberToSMS);
                //to.Add("+8613466549249");
                //to.Add("sip:xiangjun_yu@10.140.254.70:5678");
                //to.Add("sip:frank@172.16.22.128:5678");

                Message message = new Message();
                message.To = to;
                message.From = "22222222";
                message.Network = Network.SMS;
                message.Say = new Say("I am a message from yuxiangjun 1 2 3 4 5 6 7 8 9 0" + xiaoxi2shi);
                //message.PromptLogSecurity = "suppress";
                message.Voice = "en-us";

                tropo.Message(message);

                // Render the JSON for Tropo to consume.
                Response.Write(tropo.RenderJSON());
            }
        }
	}
}
