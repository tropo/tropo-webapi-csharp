using System;
using System.Web.UI;
using TropoCSharp.Structs;
using TropoCSharp.Tropo;

namespace TropoSample
{
    /// <summary>
    /// A simple example showing how to make a recording with transcription.
    /// </summary>
    public partial class RecordWithTranscription : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Create a new instance of the Tropo object.
            Tropo tropo = new Tropo();

            // Create a transcription object to use with recording.
            Transcription trancription = new Transcription();
            trancription.Uri = "mailto:homer@simpsons.com";
            trancription.EmailFormat = "omit";

            // Set up grammar for recording.
            Choices choices = new Choices();
            choices.Value = "[10 DIGITS]";
            choices.Terminator = "#";

            // Construct a prompt to use with the recording.
            Say say = new Say();
            say.Value = "Please say your account number";

            // Use the record() method to set up a recording.
            tropo.Record(3, false, true, choices, AudioFormat.Wav, 10, 60, Method.Post, null, true, say, 5, trancription, null, "http://somehost.com/record.aspx");

            // Hangup when finished.
            tropo.Hangup();
            
            // Render the JSON for Tropo to consume.
            Response.Write(tropo.RenderJSON());
        }
    }
}
