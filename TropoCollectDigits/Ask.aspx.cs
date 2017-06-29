using System;
using System.Web.UI;
using TropoCSharp.Structs;
using TropoCSharp.Tropo;

namespace TropoCollectDigits
{
    public partial class Ask: Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Create a new instance of the Tropo object.
            Tropo tropo = new Tropo();

            // Say an introductory message to the caller.
            tropo.Say("Welcome to the claim test application.");

            // Create new choices to use with Ask.
            Choices choices = new Choices("[5 DIGITS]");

            // Create new ask with desired prompt that will be sent to user.
            tropo.Ask(3, false, choices, null, "claim_id", true, new Say("Please enter your 5 digits claim ID."), 5);

            // Create On handlers for Tropo event.
            tropo.On(Event.Continue, "Answer.aspx", null);  // Fires when the user provides valid input.
            tropo.On(Event.Error, "Error.aspx", null);      // Fires when an error occurs.
            tropo.On(Event.Incomplete, "Error.aspx", null); // Fires when the user does not enter correct input.

            tropo.RenderJSON(Response);
        }
    }
}
