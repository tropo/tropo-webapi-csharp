using System;
using TropoCSharp.Structs;
using TropoCSharp.Tropo;

namespace TropoSample
{
    public partial class AskTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Create a new instance of the Tropo object.
            Tropo tropo = new Tropo();

            // Set the voice property.
            tropo.Voice = Voice.UsEnglishMale;

            tropo.Say("Alert systems");
            
            // Create a new Choices object.
            Choices choices = new Choices("[6 DIGITS]");
            choices.Mode = "dtmf"; // only digits

            // Create a new Ask.
            Ask ask = new Ask();
            ask.Choices = choices;
            ask.Attempts = 3;
            ask.Bargein = true;
            ask.Say = new Say("Please enter your six digit pass key");

            // Add action items to Tropo object.
            tropo.Ask(ask);
            tropo.On("continue", "..../VerifyPasskey", new Say(""));

            // Render JSON for Tropo to consume.
            Response.Write(tropo.RenderJSON());
        }
    }
}
