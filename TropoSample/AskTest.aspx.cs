using System;
using System.Web.UI;
using TropoCSharp.Structs;
using TropoCSharp.Tropo;

namespace TropoSample
{
    /// <summary>
    /// A simple example demonstrating how to use the Ask method.
    /// </summary>
    public partial class AskTest : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Create a new instance of the Tropo object.
            Tropo tropo = new Tropo();

            //tropo.Voice = Voice.UsEnglishFemale_Susan;
            
            // Create an array of signals - used to interupt the Ask.
            string[] signals = new string[] {"endCall", "tooLong"};

            // A prompt to use with the Ask.
            Say say = new Say("This is an Ask test with events. Please enter 1, 2 or 3.");

            // A prompt to use with the Ask.
            Say franksay = new Say("This is frank Ask test with events. Please enter 4, 6 or 2.");

            // A prompt to use with the Ask.On.
            Say sayon = new Say("This is an Ask on say");

            // Choices for the Ask.
            Choices choices = new Choices("1,2,3");

            // frank's Choices for the Ask.
            Choices frankchoices = new Choices("4,6,2");

            // Set up the dialog.
            tropo.GeneralLogSecurity("suppress");
            tropo.Ask(5, signals, false, null, choices, null, "test", Recognizer.UsEnglish, true, say, 30);
            tropo.GeneralLogSecurity("none");
            tropo.Ask(5, signals, false, null, frankchoices, null, "franktest", Recognizer.UsEnglish, true, franksay, 30);
            tropo.On("continue", "TropoResult.aspx", sayon);
            //tropo.Hangup();

            // Render the dialog JSON for Tropo to consume.
            Response.Write(tropo.RenderJSON());
        }
    }
}
