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

            Say say = new Say("Please record your 45 second message after the beep, press pound when complete.");

            tropo.Say(say);

            Record record = new Record()
            {
                Bargein = true,
                Beep = true,
                Say = new Say(""),
                Format = "audio/mp3",
                MaxTime = 45,
                Choices = new Choices("", "dtmf", "#"),
                Url = "../UploadRecording"
            };

            tropo.Record(record);

            // Render JSON for Tropo to consume.
            Response.Write(tropo.RenderJSON());
        }
    }
}
