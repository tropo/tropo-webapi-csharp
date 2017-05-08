using System;
using System.Collections.Generic;
using System.Web.UI;
using TropoCSharp.Structs;
using TropoCSharp.Tropo;

namespace TropoSample
{
    /// <summary>
    /// A simple example demonstrating how to use the Ask method.
    /// </summary>
    public partial class CallTest : Page
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

            StartRecording recording = new StartRecording(AudioFormat.Mp3, Method.Post, "http://blah.com/recordings/1234.wav", "jose", "password");

            List<String> to = new List<String>(1);
            //to.Add("sip:xiangjun_yu@10.140.254.69:5678");
            to.Add("+8613466549249");

            Call call = new Call();
            call.Recording = recording;
            call.Headers = headers;
            call.Timeout = 25;
            call.AnswerOnMedia = false;
            call.Channel = Channel.Voice;
            //call.Network = Network.SMS;
            call.To = to;
            //call.From = "3055551212";
            call.MachineDetection = new MachineDetection("我是汉语，我是甜甜，我是机器检测");
            //call.MachineDetection = new MachineDetection("For the most accurate results, the introduction should be long enough to give Tropo time to detect a human or machine. The longer the introduction, the more time we have to determine how the call was answered. If the introduction is long enough to play until the voicemail beep plays, Tropo will have the most accurate detection. It takes a minimum of four seconds to determine if a call was answered by a human or machine, so introductions four seconds or shorter will always return HUMAN.");
            //call.MachineDetection = new MachineDetection();
            //call.Voice = Voice.UsEnglishFemale_Allison;
            call.Voice = "en-us";
            call.Voice = "Tian-tian";
            call.CallbackUrl = "http://192.168.26.88:8080/FileUpload/receiveJson";
            //call.PromptLogSecurity = "";
            call.Label = "CallTestaspxcsLabel";

            //tropo.Hangup();
            tropo.Call(call);
            //tropo.Call("sip:xiangjun_yu@10.140.254.69:5678");
            tropo.Say(say1);
            //tropo.Hangup();

            //Transfer transfer = new Transfer();
            //IEnumerable<string> transferTo = new string[] { "sip:frank@172.16.22.128:5678", "sip:xiangjun_yu@10.140.254.69:5678" };
            //string from = "87473032";
            ////string[] names = { "sip:frank@172.16.22.128:5678", "sip:xiangjun_yu@10.140.254.40:5678" };
            ////to = (IEnumerable<string>)names.GetEnumerator();
            //transfer.To = transferTo;
            //transfer.From = from;
            ////transfer.AnswerOnMedia = true;
            ////On on = new On();
            ////on.Event = Event.Ring;
            ////on.Next = "http://192.168.26.55:8080/tropo/script/I.mp3";
            ////on.Next = "http://freewavesamples.com/files/Kawai-K5000W-AddSquare-C4.wav";
            ////on.Say = say3;
            ////transfer.On = on;
            //tropo.Transfer(transfer);

            ////tropo.On("ring", "http://freewavesamples.com/files/Kawai-K5000W-AddSquare-C4.wav", say3);


            ////tropo.On()

            ////tropo.Call("sip:xiangjun_yu@10.140.254.40:5678");
            ////tropo.Say(say2);
            ////tropo.Hangup();

            tropo.On("continue", "TropoResult.aspx", new Say("call test result"));

            //// Render the JSON for Tropo to consume.
            Response.Write(tropo.RenderJSON());
        }
    }
}
