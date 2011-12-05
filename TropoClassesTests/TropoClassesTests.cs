using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TropoCSharp.Tropo;
using TropoCSharp.Structs;
using System.Collections;

namespace TropoClassesTests
{
    /// <summary>
    /// A Summary description for TropoClassesTests
    /// </summary>
    [TestClass]
    public class TropoClassesTests
    {
        private string askJson = @"{""tropo"":[{ ""ask"":{""name"":""foo"",""choices"":{""value"":""[5 DIGITS]""},""say"":{""value"":""Please enter your 5 digit zip code.""}}}]}";
        private string askJsonWithEvents = @"{""tropo"":[{ ""ask"":{""attempts"":5,""allowSignals"":[""endCall"",""tooLong""],""bargein"":false,""name"":""test"",""required"":true,""choices"":{""value"":""1,2,3""},""say"":{""value"":""This is an Ask test with events. Please enter 1, 2 or 3.""},""timeout"":30.0}},{ ""hangup"":{}}]}";
        private string askJsonWithOptions = @"{""tropo"":[{ ""ask"":{""attempts"":1,""bargein"":false,""minConfidence"":30,""name"":""foo"",""required"":true,""choices"":{""value"":""[5 DIGITS]""},""say"":{""value"":""Please enter your 5 digit zip code.""},""timeout"":30.0}}]}";
        private string recordJson = @"{""tropo"":[{ ""record"":{""choices"":{""value"":""[5 DIGITS]"",""terminator"":""#""},""format"":""audio/wav"",""method"":""POST"",""required"":true,""say"":{""value"":""Please say your account number""}}}]}";
        private string recordJsonWithTranscription = @"{""tropo"":[{ ""record"":{""attempts"":1,""bargein"":false,""beep"":true,""choices"":{""value"":""[5 DIGITS]"",""terminator"":""#""},""format"":""audio/wav"",""maxSilence"":5.0,""maxTime"":30.0,""method"":""POST"",""required"":true,""say"":{""value"":""Please say your account number""},""timeout"":5.0,""password"":""foo"",""transcription"":{""id"":""foo"",""uri"":""http://example.com/"",""emailFormat"":""encoded""},""username"":""bar"",""url"":""http://example.com/""}}]}";
        private string callJson = @"{""tropo"":[{ ""call"":{""to"":[""3055195825"",""3054445567""]}}]}";
        private string callJsonAllOptions = @"{""tropo"":[{ ""call"":{""to"":[""3055195825""],""from"":""3055551212"",""network"":""SMS"",""channel"":""TEXT"",""answerOnMedia"":false,""headers"":{""foo"":""bar"",""bling"":""baz""},""recording"":{""format"":""audio/mp3"",""method"":""POST"",""url"":""http://blah.com/recordings/1234.wav"",""username"":""jose"",""password"":""password""},""timeout"":10.0}}]}";
        private string callJsonWithEvents = @"{""tropo"":[{ ""call"":{""to"":[""3055195825""],""from"":""3055551414"",""network"":""PSTN"",""channel"":""VOICE"",""answerOnMedia"":true,""allowSignals"":[""tooLong"",""callOver""],""headers"":{""x-foo"":""bar"",""x-bling"":""baz""},""timeout"":60.0}}]}";
        private string messageJson = @"{""tropo"":[{ ""message"":{""say"":{""value"":""This is an announcement""},""to"":[""3055195825""],""from"":""3055551212"",""network"":""SMS"",""channel"":""TEXT"",""answerOnMedia"":false,""timeout"":10.0,""voice"":""Kate""}}]}";
        private string messageJsonAllOptions = @"{""tropo"":[{ ""message"":{""say"":{""value"":""This is an announcement""},""to"":[""3055195825""],""from"":""3055551212"",""network"":""SMS"",""channel"":""TEXT"",""answerOnMedia"":false,""name"":""foo"",""required"":true,""timeout"":10.0,""voice"":""Kate""}}]}";
        private string startRecordingJson = @"{""tropo"":[{ ""startRecording"":{""format"":""audio/mp3"",""method"":""POST"",""url"":""http://blah.com/recordings/1234.wav"",""username"":""jose"",""password"":""password""}}]}";
        private string conferenceJson = @"{""tropo"":[{ ""call"":{""to"":[""3035551212""]}},{ ""say"":{""value"":""Welcome to the conference.""}},{ ""conference"":{""id"":""123456789098765432"",""mute"":false,""name"":""testConference"",""playTones"":false,""terminator"":""#"",""required"":true}},{ ""say"":{""value"":""Thank you for joining the conference.""}}]}";
        private string conferenceJsonWithEvents = @"{""tropo"":[{ ""call"":{""to"":[""3035551212""]}},{ ""say"":{""value"":""Welcome to the conference.""}},{ ""conference"":{""id"":""123456789098765432"",""allowSignals"":[""conferenceOver""],""mute"":false,""name"":""testConference"",""playTones"":false,""terminator"":""#"",""required"":true}}]}";

        public TropoClassesTests()
        {
        }

        #region Ask Tests

        [TestMethod]
        public void testAsk()
        {
            Say say = new Say("Please enter your 5 digit zip code.");
            Choices choices = new Choices("[5 DIGITS]");

            Tropo tropo = new Tropo();
            tropo.Ask(null, null, choices, null, "foo", null, say, null);
            Assert.AreEqual(this.askJson, tropo.RenderJSON());
        }
        
        [TestMethod]
        public void testAskFromObject()
        {
            Say say = new Say("Please enter your 5 digit zip code.");
            Choices choices = new Choices("[5 DIGITS]");
            Ask ask = new Ask(choices, "foo", say);

            Tropo tropo = new Tropo();
            tropo.Ask(ask);
            Assert.AreEqual(this.askJson, tropo.RenderJSON());
        }

        [TestMethod]
        public void testAskWithOptions()
        {
            Say say = new Say("Please enter your 5 digit zip code.");
            Choices choices = new Choices("[5 DIGITS]");
            Ask ask = new Ask();
            ask.Choices = choices;
            ask.Name = "foo";
            ask.Say = say;
            ask.Timeout = 30;
            ask.Required = true;
            ask.MinConfidence = 30;
            ask.Attempts = 1;
            ask.Bargein = false;

            Tropo tropo = new Tropo();
            tropo.Ask(ask);
            Assert.AreEqual(this.askJsonWithOptions, tropo.RenderJSON());
        }

        [TestMethod]
        public void testAskWithOptionsInDifferentOrder()
        {
            Say say = new Say("Please enter your 5 digit zip code.");
            Choices choices = new Choices("[5 DIGITS]");
            Ask ask = new Ask();
            ask.Bargein = false;
            ask.Choices = choices;
            ask.Required = true;
            ask.Attempts = 1;
            ask.Name = "foo";
            ask.Say = say;
            ask.Timeout = 30;            
            ask.MinConfidence = 30;           

            Tropo tropo = new Tropo();
            tropo.Ask(ask);
            Assert.AreEqual(this.askJsonWithOptions, tropo.RenderJSON());
        }

        [TestMethod]
        public void testAskMethodWithAllArguements()
        {
            Tropo tropo = new Tropo();
            tropo.Ask(1, false, new Choices("[5 DIGITS]"), 30, "foo", true, new Say("Please enter your 5 digit zip code."), 30);
            Assert.AreEqual(this.askJsonWithOptions, tropo.RenderJSON());
        }

        [TestMethod]
        public void testAskWithEvents()
        {
            Tropo tropo = new Tropo();
            string[] signals = new string[] { "endCall", "tooLong" };
            Say say = new Say("This is an Ask test with events. Please enter 1, 2 or 3.");
            Choices choices = new Choices("1,2,3");
            tropo.Ask(5, signals, false, null, choices, null, "test", Recognizer.UsEnglish, true, say, 30);
            tropo.Hangup();
            Assert.AreEqual(this.askJsonWithEvents, tropo.RenderJSON());
        }

        #endregion

        #region Call Tests

        [TestMethod]
        public void testToOnly()
        {
            List<String> numbersToCall = new List<String>();
            numbersToCall.Add("3055195825");
            numbersToCall.Add("3054445567");

            Tropo tropo = new Tropo();
            tropo.Call(numbersToCall);
            Assert.AreEqual(this.callJson, tropo.RenderJSON());
        }

        [TestMethod]
        public void testCallUseAllOptions()
        {
            Tropo tropo = new Tropo();

            IDictionary<string, string> headers = new Dictionary<String, String>();
            headers.Add("foo", "bar");
            headers.Add("bling", "baz");

            StartRecording recording = new StartRecording(AudioFormat.Mp3, Method.Post, "http://blah.com/recordings/1234.wav", "jose", "password");

            tropo.Call("3055195825", "3055551212", Network.SMS, Channel.Text, false, 10, headers, recording);
            Assert.AreEqual(this.callJsonAllOptions, tropo.RenderJSON());
        }

        [TestMethod]
        public void testCallUsingCallObject()
        {

            Tropo tropo = new Tropo();

            IDictionary<string, string> headers = new Dictionary<String, String>();
            headers.Add("foo", "bar");
            headers.Add("bling", "baz");

            StartRecording recording = new StartRecording(AudioFormat.Mp3, Method.Post, "http://blah.com/recordings/1234.wav", "jose", "password");

            List<String> to = new List<String>(1);
            to.Add("3055195825");

            Call call = new Call();
            call.Recording = recording;
            call.Headers = headers;
            call.Timeout = 10;
            call.AnswerOnMedia = false;
            call.Channel = Channel.Text;
            call.Network = Network.SMS;
            call.To = to;
            call.From = "3055551212";

            tropo.Call(call);
            Assert.AreEqual(this.callJsonAllOptions, tropo.RenderJSON());
        }

        [TestMethod]
        public void testCallWithEvents()
        {
            Tropo tropo = new Tropo();

            string[] signals = new string[] { "tooLong", "callOver" };

            IDictionary<string, string> headers = new Dictionary<String, String>();
            headers.Add("x-foo", "bar");
            headers.Add("x-bling", "baz");

            tropo.Call("3055195825", signals, "3055551414", Network.Pstn, Channel.Voice, true, 60, headers, null);
            Assert.AreEqual(this.callJsonWithEvents, tropo.RenderJSON());
        }

        #endregion

        #region Message Tests

        [TestMethod]
        public void testMessage()
        {
            Say say = new Say("This is an announcement");
            Tropo tropo = new Tropo();
            tropo.Voice = Voice.BritishEnglishFemale_Kate;
            string from = "3055551212";
            List<String> to = new List<String>();
            to.Add("3055195825");
            tropo.Message(say, to, false, Channel.Text, from, null, Network.SMS, null, 10);

            Assert.AreEqual(this.messageJson, tropo.RenderJSON());
        }

        [TestMethod]
        public void testMessageFromObject()
        {
            Say say = new Say("This is an announcement");
            string from = "3055551212";
            Message message = new Message();
            List<String> to = new List<String>();
            to.Add("3055195825");
            message.Say = say;
            message.To = to;
            message.From = from;
            message.AnswerOnMedia = false;
            message.Channel = Channel.Text;
            message.Network = Network.SMS;
            message.Timeout = 10;

            Tropo tropo = new Tropo();
            tropo.Voice = Voice.BritishEnglishFemale_Kate;
            tropo.Message(message);

            Assert.AreEqual(this.messageJson, tropo.RenderJSON());
        }

        [TestMethod]
        public void testMessageUseAllOptions()
        {
            Say say = new Say("This is an announcement");
            Tropo tropo = new Tropo();
            tropo.Voice = Voice.BritishEnglishFemale_Kate;
            string from = "3055551212";
            List<String> to = new List<String>();
            to.Add("3055195825");
            tropo.Message(say, to, false, Channel.Text, from, "foo", Network.SMS, true, 10);

            Assert.AreEqual(this.messageJsonAllOptions, tropo.RenderJSON());
        }

        #endregion

        #region Record Tests

        [TestMethod]
        public void testNewRecord()
        {
            Say say = new Say("Please say your account number");
            Choices choices = new Choices("[5 DIGITS]", null, "#");
            
            Tropo tropo = new Tropo();
            tropo.Record(null, null, null, choices, AudioFormat.Wav, null, null, Method.Post, null, null, say, null, null, null);
        }

        [TestMethod]
        public void testNewRecordFromObject()
        {
            Say say = new Say("Please say your account number");
            Choices choices = new Choices("[5 DIGITS]", null, "#");
            Record record = new Record();
            record.Choices = choices;
            record.Format = AudioFormat.Wav;
            record.Method = Method.Post;
            record.Say = say;
            record.Required = true;

            Tropo tropo = new Tropo();
            tropo.Record(record);
            Assert.AreEqual(this.recordJson, tropo.RenderJSON());
        }

        [TestMethod]
        public void testNewRecordObjectWithOptionsInDifferentOrder()
        {
            Say say = new Say("Please say your account number");
            Choices choices = new Choices("[5 DIGITS]", null, "#");
            Record record = new Record();
            record.Say = say;
            record.Method = Method.Post;
            record.Choices = choices;
            record.Format = AudioFormat.Wav;
            record.Required = true;

            Tropo tropo = new Tropo();
            tropo.Record(record);
            Assert.AreEqual(this.recordJson, tropo.RenderJSON());
        }
        
        [TestMethod]
        public void testRecordTranscription()
        {
            Say say = new Say("Please say your account number");
            Choices choices = new Choices("[5 DIGITS]", null, "#");
            Transcription transcription = new Transcription();

            transcription.Uri = "http://example.com/";
            transcription.Id = "foo";
            transcription.EmailFormat = "encoded";

            Tropo tropo = new Tropo();
            tropo.Record(1, false, true, choices, AudioFormat.Wav, 5, 30, Method.Post, "foo", true, say, 5, transcription, "bar", "http://example.com/"); 
            Assert.AreEqual(this.recordJsonWithTranscription, tropo.RenderJSON());
        }

        #endregion

        #region StartRecording Tests

        [TestMethod]
        public void testNewStartRecording()
        {
            Tropo tropo = new Tropo();
            tropo.StartRecording(AudioFormat.Mp3, Method.Post, "http://blah.com/recordings/1234.wav", "jose", "password");

            Assert.AreEqual(this.startRecordingJson, tropo.RenderJSON());
        }

        [TestMethod]
        public void testNewStartRecordingObject()
        {
            StartRecording startRecording = new StartRecording();
            startRecording.Format = AudioFormat.Mp3;
            startRecording.Method = Method.Post;
            startRecording.Url = "http://blah.com/recordings/1234.wav";
            startRecording.Username = "jose";
            startRecording.Password = "password";

            Tropo tropo = new Tropo();
            tropo.StartRecording(startRecording);

            Assert.AreEqual(this.startRecordingJson, tropo.RenderJSON());
        }

        #endregion

        #region Conference Tests

        [TestMethod]
        public void testConference()
        {
            Tropo tropo = new Tropo();
            tropo.Call("3035551212");
            tropo.Say("Welcome to the conference.");
            tropo.Conference("123456789098765432", false, "testConference", false, true, "#");
            tropo.Say("Thank you for joining the conference.");

            Assert.AreEqual(this.conferenceJson, tropo.RenderJSON());

        }

        [TestMethod]
        public void testConferenceWithEvents()
        {
            Tropo tropo = new Tropo();
            string[] signals = new string[] { "conferenceOver" };
            tropo.Call("3035551212");
            tropo.Say("Welcome to the conference.");
            tropo.Conference("123456789098765432", signals, false, "testConference", false, true, "#");

            Assert.AreEqual(this.conferenceJsonWithEvents, tropo.RenderJSON());
        }

        #endregion
    }
}
