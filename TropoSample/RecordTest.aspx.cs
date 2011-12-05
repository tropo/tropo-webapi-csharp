using System;
using System.Web.UI;
using TropoCSharp.Structs;
using TropoCSharp.Tropo;

namespace TropoSample
{
    /// <summary>
    /// A simple example showing how to make a recording.
    /// </summary>
    public partial class RecordTest : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Create a new instance of the Tropo object.
            Tropo tropo = new Tropo();

            // Set the voice property.
            tropo.Voice = Voice.UsEnglishMale_Steven;

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
