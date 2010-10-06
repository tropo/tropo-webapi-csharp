using System;
using TropoCSharp.Structs;
using TropoCSharp.Tropo;

namespace TropoSample
{
    public partial class RecordWithTranscription : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Create a new instance of the Tropo object.
            Tropo tropo = new Tropo();

            // Create a transcription object to use with recording.
            Transcription trancription = new Transcription();
            trancription.url = "mailto:homer@simpsons.com";
            trancription.emailFormat = "omit";

            // Set up grammar for recording.
            Choices choices = new Choices();
            choices.value = "[10 DIGITS]";
            choices.terminator = "#";

            // Construct a prompt to use with the recording.
            Say say = new Say();
            say.value = "Please say your account number";

            // Use the record() method to set up a recording.
            tropo.record(3, false, true, choices, AudioFormat.wav, 10, 60, Method.post, null, true, say, 5, trancription, null, "http://somehost.com/record.aspx");

            // Hangup when finished.
            tropo.hangup();
            
            // Render the JSON for Tropo to consume.
            Response.Write(TropoJSON.render(tropo));
        }
    }
}
