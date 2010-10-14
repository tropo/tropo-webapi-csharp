using System;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TropoCSharp.Tropo;
using TropoCSharp.Structs;
using System.Collections.Generic;

namespace TropoSample
{
    public partial class SendMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Create a new instance of the Tropo object.
            Tropo tropo = new Tropo();

            // Set the voice to use when saying a prompt.
            tropo.Voice = Voice.UsEnglishMale;

            // A prompt to give the say to the recipient.
            Say say = new Say("Remember you have a meeting at 2 PM");
            
            // An ArrayList to hold the numbers to call (first call answered hears the prompt).
            List<String> to = new List<String>();
            to.Add("3055195825");
            to.Add("3054445567");

            // Create an endpoint object to denote who the call is from.
            Endpoint from = new Endpoint("7777777777", null, null, null);

            // Call the message method of the Tropo object and pass in values.
            tropo.Message(say, to, false, Channel.Voice, from, "reminder", Network.Pstn, true, 60);

            // Render the JSON for Tropo to consume.
            Response.Write(tropo.RenderJSON());
        }
    }
}
