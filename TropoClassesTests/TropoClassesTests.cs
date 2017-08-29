using System;
using System.Text;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TropoCSharp.Tropo;
using TropoCSharp.Structs;
using System.Collections;
using Newtonsoft.Json;

namespace TropoClassesTests
{
    /// <summary>
    /// A Summary description for TropoClassesTests
    /// </summary>
    [TestClass]
    public class TropoClassesTests
    {
        private string askJson = @"{""tropo"":[{ ""ask"":{""name"":""foo"",""choices"":{""value"":""[5 DIGITS]""},""say"":[{""value"":""Please enter your 5 digit zip code.""}]}}]}";
        private string askJsonWithEvents = @"{""tropo"":[{ ""ask"":{""attempts"":5,""allowSignals"":[""endCall"",""tooLong""],""bargein"":false,""name"":""test"",""recognizer"":""en-us"",""required"":true,""choices"":{""value"":""1,2,3""},""say"":[{""value"":""This is an Ask test with events. Please enter 1, 2 or 3.""}],""timeout"":30.0}},{ ""hangup"":{}}]}";
        private string askJsonWithOptions = @"{""tropo"":[{ ""ask"":{""attempts"":1,""bargein"":false,""minConfidence"":30,""name"":""foo"",""required"":true,""choices"":{""value"":""[5 DIGITS]""},""say"":[{""value"":""Please enter your 5 digit zip code.""}],""timeout"":30.0}}]}";
        private string askJsonWithLogArguements = @"{""tropo"":[{ ""ask"":{""attempts"":5,""allowSignals"":[""endCall"",""tooLong""],""bargein"":false,""minConfidence"":30,""name"":""foo"",""recognizer"":""en-us"",""required"":true,""choices"":{""value"":""[5 DIGITS]""},""say"":[{""value"":""Please enter your 5 digit zip code.""}],""timeout"":30.0,""promptLogSecurity"":""suppress"",""asrLogSecurity"":""mask"",""maskTemplate"":""XXDD-""}}]}";
        private string askJsonWithLogArguements2 = @"{""tropo"":[{ ""ask"":{""attempts"":5,""allowSignals"":[""endCall"",""tooLong""],""bargein"":false,""minConfidence"":30,""name"":""foo"",""recognizer"":""en-us"",""required"":true,""choices"":{""value"":""[5 DIGITS]""},""say"":[{""value"":""Please enter your 5 digit zip code.""}],""sensitivity"":2,""speechCompleteTimeout"":3.0,""speechIncompleteTimeout"":4.0,""timeout"":30.0,""promptLogSecurity"":""suppress"",""asrLogSecurity"":""mask"",""maskTemplate"":""XXDD-""}}]}";
        private string askJsonWithSayEvents = @"{""tropo"":[{ ""ask"":{""interdigitTimeout"":1,""name"":""foo"",""choices"":{""value"":""[5 DIGITS]""},""say"":[{""value"":""Are you still there?"",""event"":""timeout""},{""value"":""Please enter your 5 digit zip code.""}]}}]}";
        private string recordJson = @"{""tropo"":[{ ""record"":{""choices"":{""value"":""[5 DIGITS]"",""terminator"":""#""},""format"":""audio/wav"",""method"":""POST"",""required"":true,""say"":{""value"":""Please say your account number""}}}]}";
        private string recordJsonWithTranscription = @"{""tropo"":[{ ""record"":{""attempts"":1,""bargein"":false,""beep"":true,""choices"":{""value"":""[5 DIGITS]"",""terminator"":""#""},""format"":""audio/wav"",""maxSilence"":5.0,""maxTime"":30.0,""method"":""POST"",""required"":true,""say"":{""value"":""Please say your account number""},""timeout"":5.0,""password"":""foo"",""transcription"":{""id"":""foo"",""url"":""http://example.com/"",""emailFormat"":""encoded""},""username"":""bar"",""url"":""http://example.com/""}}]}";
        private string recordJsonAllOptions = @"{""tropo"":[{ ""record"":{""attempts"":1,""bargein"":false,""beep"":true,""choices"":{""value"":""[5 DIGITS]"",""terminator"":""#""},""format"":""audio/wav"",""interdigitTimeout"":5,""maxSilence"":10.0,""maxTime"":600.0,""method"":""POST"",""name"":""whname"",""required"":true,""say"":{""value"":""Please say your account number""},""timeout"":15.0,""transcription"":{""id"":""foo"",""url"":""http://example.com/"",""emailFormat"":""encoded""},""url"":""http://example.com/"",""asyncUpload"":true,""promptLogSecurity"":""none"",""sensitivity"":0.99}}]}";
        private string callJson = @"{""tropo"":[{ ""call"":{""to"":[""3055195825"",""3054445567""]}}]}";
        private string callJsonAllOptions = @"{""tropo"":[{ ""call"":{""to"":[""3055195825""],""from"":""3055551212"",""network"":""SMS"",""channel"":""TEXT"",""answerOnMedia"":false,""headers"":{""foo"":""bar"",""bling"":""baz""},""timeout"":10.0}}]}";
        private string callJsonCallObject = @"{""tropo"":[{ ""call"":{""to"":[""3055195825""],""from"":""3055551212"",""network"":""SMS"",""channel"":""TEXT"",""answerOnMedia"":false,""headers"":{""foo"":""bar"",""bling"":""baz""},""timeout"":10.0,""machineDetection"":{""introduction"":""It is rather for us to be here dedicated to the great task remaining before us—that from these honored dead we take increased devotion to that cause for which they here gave the last full measure of devotion—that we here highly resolve that these dead shall not have died in vain—that this nation, under God, shall have a new birth of freedom, and that government of the people, by the people, for the people, shall not perish from the earth.""},""voice"":""voicefoo"",""callbackUrl"":""samplecallbackurl"",""label"":""appidIdAsLabel""}}]}";
        private string callJsonWithEvents = @"{""tropo"":[{ ""call"":{""to"":[""3055195825""],""from"":""3055551414"",""network"":""PSTN"",""channel"":""VOICE"",""answerOnMedia"":true,""allowSignals"":[""tooLong"",""callOver""],""headers"":{""x-foo"":""bar"",""x-bling"":""baz""},""timeout"":60.0}}]}";
        private string messageJson = @"{""tropo"":[{ ""message"":{""say"":{""value"":""This is an announcement""},""to"":[""3055195825""],""from"":""3055551212"",""network"":""SMS"",""channel"":""TEXT"",""answerOnMedia"":false,""timeout"":10.0,""voice"":""Kate"",""promptLogSecurity"":""none""}}]}";
        private string messageJsonAllOptions = @"{""tropo"":[{ ""message"":{""say"":{""value"":""This is an announcement""},""to"":[""3055195825""],""from"":""3055551212"",""network"":""SMS"",""channel"":""TEXT"",""answerOnMedia"":false,""name"":""foo"",""required"":true,""timeout"":10.0,""voice"":""voicee"",""promptLogSecurity"":""none""}}]}";
        private string startRecordingAsyncUploadJson = @"{""tropo"":[{ ""startRecording"":{""asyncUpload"":true,""format"":""audio/mp3"",""method"":""POST"",""url"":""http://blah.com/recordings/1234.wav"",""username"":""jose"",""password"":""password"",""transcriptionID"":"""",""transcriptionEmailFormat"":""plain"",""transcriptionOutURI"":""""}}]}";
        private string startRecordingJson = @"{""tropo"":[{ ""startRecording"":{""format"":""audio/mp3"",""method"":""POST"",""url"":""http://blah.com/recordings/1234.wav"",""username"":""jose"",""password"":""password""}}]}";
        private string conferenceJson = @"{""tropo"":[{ ""call"":{""to"":[""3035551212""]}},{ ""say"":{""value"":""Welcome to the conference.""}},{ ""conference"":{""id"":""123456789098765432"",""mute"":false,""name"":""testConference"",""playTones"":false,""terminator"":""#"",""required"":true}},{ ""say"":{""value"":""Thank you for joining the conference.""}}]}";
        private string conferenceJsonWithEvents = @"{""tropo"":[{ ""call"":{""to"":[""3035551212""]}},{ ""say"":{""value"":""Welcome to the conference.""}},{ ""conference"":{""id"":""123456789098765432"",""allowSignals"":[""conferenceOver""],""mute"":false,""name"":""testConference"",""playTones"":false,""terminator"":""#"",""required"":true}}]}";
        private string conferenceJsonWithWithPromptsAndpromptLogSecurity = @"{""tropo"":[{ ""call"":{""to"":[""3035551212""]}},{ ""say"":{""value"":""Welcome to the conference.""}},{ ""conference"":{""id"":""123456789098765432"",""allowSignals"":[""conferenceOver""],""interdigitTimeout"":4,""mute"":false,""name"":""testConference"",""playTones"":false,""terminator"":""#"",""required"":true,""joinPrompt"":{""value"":""somebody join the conference""},""leavePrompt"":{""value"":""some one leave the conference""},""promptLogSecurity"":""none""}}]}";
        private string generalLogSecurityJson = @"{""tropo"":[{""generalLogSecurity"":""suppress""},{ ""say"":{""value"":""this is not logged""}},{""generalLogSecurity"":""none""},{ ""say"":{""value"":""this will be logged""}}]}";
        private string redirectJson = @"{""tropo"":[{ ""redirect"":{""name"":""redirectTest"",""required"":true,""to"":""sip:9995844724@10.140.254.62:5678""}}]}";
        private string sayJson = @"{""tropo"":[{ ""say"":{""value"":""hello Moscow"",""name"":""shname"",""promptLogSecurity"":""suppress""}}]}";

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

            var rendered = renderJSONToText(tropo);

            Assert.AreEqual(this.askJson, rendered);
        }

        [TestMethod]
        public void testAskWithSayEvents()
        {
            var says = new Collection<Say>();
            says.Add(new Say("Are you still there?", "timeout"));
            says.Add(new Say("Please enter your 5 digit zip code."));

            Choices choices = new Choices("[5 DIGITS]");

            Tropo tropo = new Tropo();
            tropo.Ask(null, null, 1, choices, null, "foo", null, says, null);

            var rendered = renderJSONToText(tropo);

            Assert.AreEqual(this.askJsonWithSayEvents, rendered);
        }
        
        [TestMethod]
        public void testAskFromObject()
        {
            Say say = new Say("Please enter your 5 digit zip code.");
            Choices choices = new Choices("[5 DIGITS]");
            Ask ask = new Ask(choices, "foo", say);

            Tropo tropo = new Tropo();
            tropo.Ask(ask);
            Assert.AreEqual(this.askJson, renderJSONToText(tropo));
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
            Assert.AreEqual(this.askJsonWithOptions, renderJSONToText(tropo));
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
            Assert.AreEqual(this.askJsonWithOptions, renderJSONToText(tropo));
        }

        [TestMethod]
        public void testAskMethodWithAllArguements()
        {
            Tropo tropo = new Tropo();
            tropo.Ask(1, false, new Choices("[5 DIGITS]"), 30, "foo", true, new Say("Please enter your 5 digit zip code."), 30);
            Assert.AreEqual(this.askJsonWithOptions, renderJSONToText(tropo));
        }

        [TestMethod]
        public void testAskMethodWithLogArguements()
        {
            Tropo tropo = new Tropo();
            // Create an array of signals - used to interupt the Ask.
            string[] signals = new string[] { "endCall", "tooLong" };
            tropo.Ask(5, signals, false, null, new Choices("[5 DIGITS]"), 30, "foo", Recognizer.UsEnglish, true, new Say("Please enter your 5 digit zip code."), 30, "suppress", "mask", "XXDD-");
            Assert.AreEqual(this.askJsonWithLogArguements, renderJSONToText(tropo));
        }

        [TestMethod]
        public void testAskMethodWithLogArguements2()
        {
            Tropo tropo = new Tropo();
            // Create an array of signals - used to interupt the Ask.
            string[] signals = new string[] { "endCall", "tooLong" };
            tropo.Ask(5, signals, false, null, new Choices("[5 DIGITS]"), 30, "foo", Recognizer.UsEnglish, true, new Say("Please enter your 5 digit zip code."), 2, 3.0f, 4.0f, 30, "suppress", "mask", "XXDD-");
            Assert.AreEqual(this.askJsonWithLogArguements2, renderJSONToText(tropo));
        }

        [TestMethod]
        public void testAskWithEvents()
        {
            Tropo tropo = new Tropo();
            string[] signals = new string[] { "endCall", "tooLong" };
            Say say = new Say("This is an Ask test with events. Please enter 1, 2 or 3.");
            Choices choices = new Choices("1,2,3");
            //tropo.Ask(5, signals, false, null, choices, null, "test", Recognizer.UsEnglish, "suppress", "mask", "XXDD-", true, say, 30);
            tropo.Ask(5, signals, false, null, choices, null, "test", Recognizer.UsEnglish, true, say, 30);
            tropo.Hangup();
            var rendered = renderJSONToText(tropo);

            Assert.AreEqual(this.askJsonWithEvents, rendered);
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
            Assert.AreEqual(this.callJson, renderJSONToText(tropo));
        }

        [TestMethod]
        public void testCallUseAllOptions()
        {
            Tropo tropo = new Tropo();

            IDictionary<string, string> headers = new Dictionary<String, String>();
            headers.Add("foo", "bar");
            headers.Add("bling", "baz");


            tropo.Call("3055195825", "3055551212", Network.SMS, Channel.Text, false, 10, headers);
            Assert.AreEqual(this.callJsonAllOptions, renderJSONToText(tropo));
        }

        [TestMethod]
        public void testCallUsingCallObject()
        {

            Tropo tropo = new Tropo();

            IDictionary<string, string> headers = new Dictionary<String, String>();
            headers.Add("foo", "bar");
            headers.Add("bling", "baz");


            List<String> to = new List<String>(1);
            to.Add("3055195825");

            Call call = new Call();
            call.Headers = headers;
            call.Timeout = 10;
            call.AnswerOnMedia = false;
            call.Channel = Channel.Text;
            call.Network = Network.SMS;
            call.To = to;
            call.From = "3055551212";
            call.MachineDetection = new MachineDetection("It is rather for us to be here dedicated to the great task remaining before us—that from these honored dead we take increased devotion to that cause for which they here gave the last full measure of devotion—that we here highly resolve that these dead shall not have died in vain—that this nation, under God, shall have a new birth of freedom, and that government of the people, by the people, for the people, shall not perish from the earth.");
            call.CallbackUrl = "samplecallbackurl";
            call.Voice = "voicefoo";
            call.Label = "appidIdAsLabel";

            tropo.Call(call);
            Assert.AreEqual(this.callJsonCallObject, renderJSONToText(tropo));
        }

        [TestMethod]
        public void testCallWithEvents()
        {
            Tropo tropo = new Tropo();

            string[] signals = new string[] { "tooLong", "callOver" };

            IDictionary<string, string> headers = new Dictionary<String, String>();
            headers.Add("x-foo", "bar");
            headers.Add("x-bling", "baz");

            tropo.Call("3055195825", signals, "3055551414", Network.Pstn, Channel.Voice, true, 60, headers);
            Assert.AreEqual(this.callJsonWithEvents, renderJSONToText(tropo));
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
            tropo.Message(say, to, false, Channel.Text, from, null, Network.SMS, null, 10, Voice.BritishEnglishFemale_Kate, "none");

            Assert.AreEqual(this.messageJson, renderJSONToText(tropo));
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
            message.PromptLogSecurity = "none";

            Tropo tropo = new Tropo();
            tropo.Voice = Voice.BritishEnglishFemale_Kate;
            tropo.Message(message);

            Assert.AreEqual(this.messageJson, renderJSONToText(tropo));
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
            tropo.Message(say, to, false, Channel.Text, from, "foo", Network.SMS, true, 10, "voicee", "none");

            Assert.AreEqual(this.messageJsonAllOptions, renderJSONToText(tropo));
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
            Assert.AreEqual(this.recordJson, renderJSONToText(tropo));
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
            Assert.AreEqual(this.recordJson, renderJSONToText(tropo));
        }

        [TestMethod]
        public void testRecordTranscription()
        {
            Say say = new Say("Please say your account number");
            Choices choices = new Choices("[5 DIGITS]", null, "#");
            Transcription transcription = new Transcription();

            transcription.Url = "http://example.com/";
            transcription.Id = "foo";
            transcription.EmailFormat = "encoded";

            Tropo tropo = new Tropo();
            tropo.Record(1, false, true, choices, AudioFormat.Wav, 5, 30, Method.Post, "foo", true, say, 5, transcription, "bar", "http://example.com/");
            Assert.AreEqual(this.recordJsonWithTranscription, renderJSONToText(tropo));
        }

        [TestMethod]
        public void testRecordAllOptions()
        {
            Say say = new Say("Please say your account number");
            Choices choices = new Choices("[5 DIGITS]", null, "#");
            Transcription transcription = new Transcription();

            transcription.Url = "http://example.com/";
            transcription.Id = "foo";
            transcription.EmailFormat = "encoded";

            Tropo tropo = new Tropo();
            //tropo.Record(1, false, true, choices, AudioFormat.Wav, 5, 30, Method.Post, "foo", true, say, 5, transcription, "bar", "http://example.com/");
            tropo.Record(1, true, null, false, true, choices, say, AudioFormat.Wav, 10, 600, Method.Post, "whname", true, transcription, "http://example.com/", null, null, 15, 5, null, "none", 0.99f);
            Assert.AreEqual(this.recordJsonAllOptions, renderJSONToText(tropo));
        }

        #endregion

        #region StartRecording Tests

        /// <summary>
        /// since 2017-04-20
        /// </summary>
        [TestMethod]
        public void testStartRecordingAsyncUpload()
        {
            Tropo tropo = new Tropo();
            tropo.StartRecording(true,AudioFormat.Mp3, Method.Post, "http://blah.com/recordings/1234.wav", "jose", "password", "", "plain", "");

            Assert.AreEqual(this.startRecordingAsyncUploadJson, renderJSONToText(tropo));
        }

        [TestMethod]
        public void testNewStartRecording()
        {
            Tropo tropo = new Tropo();
            tropo.StartRecording(AudioFormat.Mp3, Method.Post, "http://blah.com/recordings/1234.wav", "jose", "password");

            Assert.AreEqual(this.startRecordingJson, renderJSONToText(tropo));
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

            Assert.AreEqual(this.startRecordingJson, renderJSONToText(tropo));
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

            Assert.AreEqual(this.conferenceJson, renderJSONToText(tropo));

        }

        [TestMethod]
        public void testConferenceWithEvents()
        {
            Tropo tropo = new Tropo();
            string[] signals = new string[] { "conferenceOver" };
            tropo.Call("3035551212");
            tropo.Say("Welcome to the conference.");
            tropo.Conference("123456789098765432", signals, false, "testConference", false, true, "#");

            Assert.AreEqual(this.conferenceJsonWithEvents, renderJSONToText(tropo));
        }

        [TestMethod]
        public void testConferenceWithPromptsAndpromptLogSecurity()
        {
            Tropo tropo = new Tropo();
            string[] signals = new string[] { "conferenceOver" };
            tropo.Call("3035551212");
            tropo.Say("Welcome to the conference.");
            JoinPrompt joinPrompt = new JoinPrompt("somebody join the conference");
            LeavePrompt leavePrompt = new LeavePrompt("some one leave the conference");
            tropo.Conference("123456789098765432", signals, 4, false, "testConference", false, true, "#", joinPrompt, leavePrompt, "none");

            Assert.AreEqual(this.conferenceJsonWithWithPromptsAndpromptLogSecurity, renderJSONToText(tropo));
        }

        [TestMethod]
        public void testGeneralLogSecurity()
        {
            Tropo tropo = new Tropo();
            tropo.GeneralLogSecurity("suppress");
            tropo.Say("this is not logged");
            tropo.GeneralLogSecurity("none");
            tropo.Say("this will be logged");

            Assert.AreEqual(this.generalLogSecurityJson, renderJSONToText(tropo));
        }

        #endregion


        #region Redirect Tests

        [TestMethod]
        public void testRedirect()
        {
            Tropo tropo = new Tropo();
            tropo.Redirect("sip:9995844724@10.140.254.62:5678", "redirectTest", true);

            Assert.AreEqual(this.redirectJson, renderJSONToText(tropo));
        }

        #endregion

        #region Say Tests

        [TestMethod]
        public void testSay()
        {
            Tropo tropo = new Tropo();
            tropo.Say("hello Moscow", null, null, "shname", null, null, "suppress");

            Assert.AreEqual(this.sayJson, renderJSONToText(tropo));
        }

        #endregion

        private string renderJSONToText(Tropo tropo)
        {
            tropo.Language = null;
            tropo.Voice = null;
            JsonSerializerSettings settings = new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore };
            return JsonConvert.SerializeObject(tropo, Formatting.None, settings).Replace("\\\"", "\"").Replace("\\\\", "\\").Replace("\"{", "{").Replace("}\"", "}");
        }

    }
}
