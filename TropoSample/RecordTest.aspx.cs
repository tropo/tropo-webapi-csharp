using System;
using System.Collections.Generic;
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
            //tropo.Voice = Voice.UsEnglishMale_Steven;

            Say say = new Say("Please record your 45 second message after the beep, press pound when complete.");

            tropo.Say(say);

            RecordUrlTuple RecordUrlTuple1 = new RecordUrlTuple()
            {
                Url = "http://fakeurl.one.com",
                Username = "user1",
                Password = "password1",
                Method = "POST"
            };

            RecordUrlTuple RecordUrlTuple2 = new RecordUrlTuple()
            {
                Url = "http://192.168.26.88:8080/FileUpload/uploadFile",
                //Username = "user2",
                //Password = ""
                //Method = "POST"

            };

            RecordUrlTuple RecordUrlTuple3 = new RecordUrlTuple()
            {
                Url = "http://fakeurl.three.com",
                Password = "password3",
                Method = "PUT"

            };

            RecordUrlTuple RecordUrlTuple4 = new RecordUrlTuple()
            {
                Url = "http://fakeurl.four.com",
                Password = "password3",
                Method = "put"

            };

            IEnumerable<RecordUrlTuple> recordingURL = new RecordUrlTuple[] { RecordUrlTuple1, RecordUrlTuple2, RecordUrlTuple3, RecordUrlTuple4 };

            Record record = new Record()
            {
                Bargein = true,
                Beep = true,
                Say = new Say("this is say in record"),
                Format = "audio/mp3",
                MaxTime = 45,
                Choices = new Choices("", "dtmf", "#"),
                //Choices = new Choices("#"),
                //Url = "http://192.168.26.88:8080/FileUpload/uploadFile",
                RecordingURL = recordingURL
            };

            tropo.Record(record);

            tropo.RenderJSON(Response);
        }
    }
}
