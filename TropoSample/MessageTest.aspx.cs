using System;
using System.Collections.Generic;
using System.Web.UI;
using TropoCSharp.Tropo;

namespace TropoSamples
{
	/// <summary>
	/// A simple example showing how to say Hello World to a user.
	/// </summary>
    public partial class MessageTest : Page
	{
		public void Page_Load (object sender, EventArgs args)
		{
            // Create a new instance of the Tropo object.
            Tropo tropo = new Tropo();

            // Call the say method of the Tropo object and give it a prompt to say.
            //tropo.Say("Hello World!");

            List<String> to = new List<String>(1);
            to.Add("sip:xiangjun_yu@10.140.254.70:5678");
            to.Add("sip:frank@172.16.22.128:5678");

            Message message = new Message();
            message.To = to;
            message.From = "sip:foosip@foo.com";
            message.Say = new Say("I am a message 1");
            message.PromptLogSecurity = "suppress";
            message.Voice = "en-us";

            tropo.Message(message);

            // Render the JSON for Tropo to consume.
            Response.Write(tropo.RenderJSON());
		}
	}
}
