using System;
using TropoCSharp.Tropo;

namespace TropoSample
{
    public partial class AskTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Create a new instance of the Tropo object.
            Tropo tropo = new Tropo();
            
            // Create an array of signals - used to interupt the Ask.
            string[] signals = new string[] {"endCall", "tooLong"};

            // A prompt to use with the Ask.
            Say say = new Say("This is an Ask test with events. Please enter 1, 2 or 3.");

            // Choices for the Ask.
            Choices choices = new Choices("1,2,3");

            // Set up the dialog.
            tropo.Ask(5, signals, false, choices, null, "test", true, say, 30);
            tropo.Hangup();

            // Render the dialog JSON for Tropo to consume.
            Response.Write(tropo.RenderJSON());
        }
    }
}
