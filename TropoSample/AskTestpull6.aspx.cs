using System;
using System.Collections.ObjectModel;
using System.Web.UI;
using TropoCSharp.Structs;
using TropoCSharp.Tropo;

namespace TropoSample
{
    /// <summary>
    /// A simple example demonstrating how to use the Ask method.
    /// </summary>
    public partial class AskTestpull6 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Create a new instance of the Tropo object.
            Tropo tropo = new Tropo();

            //tropo.Voice = Voice.UsEnglishFemale_Susan;
            
            // Create an array of signals - used to interupt the Ask.
            // string[] signals = new string[] {"endCall", "tooLong"};

            // A prompt to use with the Ask.
            Say say = new Say("This is an Ask test with events. Please enter 1, 2 or 3.");

            var says = new Collection<Say>();
            says.Add(new Say("Sorry, I did not hear anything.", "timeout"));
            says.Add(new Say("Don't think that was a year. ", "nomatch:1"));
            says.Add(new Say("Nope, still not a year.", "nomatch:2"));
            says.Add(new Say("No match 3.", "nomatch:3"));
            says.Add(new Say("What is your birth year?"));


            // Choices for the Ask.
            Choices choices = new Choices("[4 DIGITS]");

            // Set up the dialog.
            tropo.Ask(4, true, 1, choices, null, "year", true, says, 60);
            tropo.On(Event.Continue, "YourAge.aspx", null);  // Fires when the user provides valid input.
            tropo.On(Event.Incomplete, "AgeFail.aspx", null);  // Fires when the user provides valid input.

            //tropo.Hangup();

            // Render the dialog JSON for Tropo to consume.
            Response.Write(tropo.RenderJSON());
        }
    }
}
