using System;
using System.Collections.ObjectModel;
using System.Web;
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
            trancription.Url = "http://54.88.99.156:9080/FileUpload/receiveJson";
            trancription.EmailFormat = "omit";
            trancription.Id = "5499receivejjson";

            Transcription trancription2 = new Transcription();
            trancription2.Url = "mailto:xiangjun919@gmail.com";
            trancription2.EmailFormat = "omit";
            trancription2.Id = "gmail567yuhj";

            var trancriptions = new Collection<Transcription>();
            trancriptions.Add(trancription);
            //trancriptions.Add(trancription2);
            // Set up grammar for recording.
            Choices choices = new Choices();
            choices.Value = "[10 DIGITS]";
            choices.Terminator = "#";

            // Construct a prompt to use with the recording.
            Say say = new Say();
            say.Value = "Please say your account number, Please say your account number again";

            Say sayqq = new Say();
            sayqq.Value = "why I got an error";
            sayqq.Name = "lucas";

            //say.Value = "Fourscore and seven years ago our fathers brought forth, on this continent, a new nation, conceived in liberty, and dedicated to the proposition that all men are created equal.Now we are engaged in a great civil war, testing whether that nation, or any nation so conceived, and so dedicated, can long endure. We are met on a great battle - field of that war.We have come to dedicate a portion of that field, as a final resting-place for those who here gave their lives, that that nation might live.It is altogether fitting and proper that we should do this.But, in a larger sense, we cannot dedicate, we cannot consecrate—we cannot hallow—this ground.The brave men, living and dead, who struggled here, have consecrated it far above our poor power to add or detract. The world will little note, nor long remember what we say here, but it can never forget what they did here. It is for us the living, rather, to be dedicated here to the unfinished work which they who fought here have thus far so nobly advanced.It is rather for us to be here dedicated to the great task remaining before us—that from these honored dead we take increased devotion to that cause for which they here gave the last full measure of devotion—that we here highly resolve that these dead shall not have died in vain—that this nation, under God, shall have a new birth of freedom, and that government of the people, by the people, for the people, shall not perish from the earth.";
            tropo.Call("+8613466549249");
            // Use the record() method to set up a recording.
            //tropo.Record(3, false, true, choices, AudioFormat.Wav, 10, 600, Method.Post, null, true, say, 15, trancription, null, "http://54.88.99.156:9080/FileUpload/uploadFile");
            tropo.Record(3, null, null, null, null, choices, say, AudioFormat.Wav, 10, 600, Method.Post, "swift", true, trancription, "http://54.88.99.156:9080/FileUpload/uploadFile", null, null, 15, 5, null, null);
            //tropo.Say(sayqq);
            Say franksay = new Say("This is frank ask. Please enter your 5 digits credit card number.");
            Choices frankchoices = new Choices("[5 DIGITS]", "dtmf", "#");
            //tropo.Ask(5, null, false, null, frankchoices, null, "frank test", Recognizer.UsEnglish, true, franksay, 30, "suppress", "mask", "XXDD-");
            tropo.On("continue", "TropoResult.aspx", new Say("This is a on say in record" ));
            // Hangup when finished.
            //tropo.Hangup();

            HttpContext.Current.Trace.Warn("learn trace of dot net" + DateTime.Now.ToString());

            // Render the JSON for Tropo to consume.
            Response.Write(tropo.RenderJSON());
        }
    }
}
