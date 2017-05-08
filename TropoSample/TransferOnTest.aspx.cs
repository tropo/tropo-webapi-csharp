using System;
using System.Collections.Generic;
using System.Web.UI;
using TropoCSharp.Structs;
using TropoCSharp.Tropo;

namespace TropoSamples
{
    /// <summary>
    /// A simple example demonstrating how to use the Ask method.
    /// </summary>
    public partial class TransferOnTest : Page
    {
        public void Page_Load(object sender, EventArgs args)
        {
            // Create a new instance of the Tropo object.
            Tropo tropo = new Tropo();

            Say say1 = new Say("Are you frank on windows. thanks to jerry");
            Say say2 = new Say("Are you frank on Mac.  thanks to jerry");
            Say say3 = new Say("http://192.168.26.55:8080/tropo/script/I.mp3");

            // Choices for the Ask.
            //Choices choices = new Choices("1,2,3");

            // Set up the dialog.
            //tropo.Call("sip:frank@172.16.22.128:5678");

            IDictionary<string, string> headers = new Dictionary<String, String>();
            headers.Add("foo", "bar");
            headers.Add("bling", "baz");


            List<String> to = new List<String>(1);
            to.Add("sip:xiangjun_yu@10.140.254.70:5678");
            //to.Add("sip:frank@172.16.22.128:5678");

            Call call = new Call();
            call.Headers = headers;
            call.Timeout = 10;
            call.AnswerOnMedia = false;
            call.Channel = Channel.Voice;
            //call.Network = Network.SMS;
            call.To = to;
            //call.From = "3055551212";
            call.MachineDetection = new MachineDetection("For the most accurate results, the introduction should be long enough to give Tropo time to detect a human or machine.");
            //call.MachineDetection = new MachineDetection();
            //call.Voice = Voice.UsEnglishFemale_Allison;
            call.Voice = "en-us";
            //call.CallbackUrl = "http://192.168.26.88:8080/FileUpload/uploadFile";
            //call.CallbackUrl = "http://requestb.in/zm7e2zzm";
            call.CallbackUrl = "http://192.168.26.88:8080/FileUpload/receiveJson";
            //call.PromptLogSecurity = "none";
            call.Label = "TransferOnTestasxpxcsLabel";

            //tropo.Hangup();
            tropo.Call(call);
            //tropo.Call("sip:xiangjun_yu@10.140.254.69:5678");
            tropo.Say(say1);
            //tropo.Hangup();

            Transfer transfer = new Transfer();
            IEnumerable<string> transferTo = new string[] { "sip:frank@172.16.22.128:5678", "sip:xiangjun_yu@10.140.254.70:5678" };
            string from = "87473032";
            //string[] names = { "sip:frank@172.16.22.128:5678", "sip:xiangjun_yu@10.140.254.40:5678" };
            //to = (IEnumerable<string>)names.GetEnumerator();
            transfer.To = transferTo;
            transfer.From = from;
            transfer.AnswerOnMedia = true;
            On on = new On();
            on.Event = "connect";
            on.Next = "http://192.168.26.55:8080/tropo/script/I.mp3";
            on.Next = "http://freewavesamples.com/files/Kawai-K5000W-AddSquare-C4.wav";
            on.Say = say3;
            //on.Post = "http://requestb.in/1cp3mf01";
            on.Post = "http://192.168.26.88:8080/FileUpload/receiveJson";
            transfer.On = on;
            tropo.Transfer(transfer);

            ////tropo.On("ring", "http://freewavesamples.com/files/Kawai-K5000W-AddSquare-C4.wav", say3);


            ////tropo.On()

            ////tropo.Call("sip:xiangjun_yu@10.140.254.40:5678");
            ////tropo.Say(say2);
            ////tropo.Hangup();


            //tropo.On("continue", "TropoResult.aspx", new Say("call test result"));

            //// Render the JSON for Tropo to consume.
            Response.Write(tropo.RenderJSON());
        }
    }
}
