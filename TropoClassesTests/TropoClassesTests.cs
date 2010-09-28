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
        private string askJson = @"{""tropo"":[{ ""ask"":{""choices"":{""value"":""[5 DIGITS]""},""name"":""foo"",""say"":{""value"":""Please enter your 5 digit zip code.""}}}]}";
        private string askJsonWithOptions = @"{""tropo"":[{ ""ask"":{""choices"":{""value"":""[5 DIGITS]""},""attempts"":1,""bargein"":false,""minConfidence"":30,""name"":""foo"",""required"":true,""say"":{""value"":""Please enter your 5 digit zip code.""},""timeout"":30.0}}]}";
        private string recordJson = @"{""tropo"":[{ ""record"":{""choices"":{""value"":""[5 DIGITS]"",""termChar"":""#""},""required"":true,""say"":{""value"":""Please say your account number""},""format"":""audio/wav"",""method"":""POST""}}]}";
        private string recordJsonWithTranscription = @"{""tropo"":[{ ""record"":{""choices"":{""value"":""[5 DIGITS]"",""termChar"":""#""},""attempts"":1,""bargein"":false,""required"":true,""say"":{""value"":""Please say your account number""},""timeout"":5.0,""format"":""audio/wav"",""maxSilence"":5.0,""maxTime"":30.0,""method"":""POST"",""password"":""foo"",""transcription"":{""id"":""foo"",""url"":""http://example.com/"",""emailFormat"":""encoded""},""username"":""bar"",""url"":""http://example.com/"",""beep"":true}}]}";
        private string callJson = @"{""tropo"":[{ ""call"":{""to"":[""3055195825"",""3054445567""]}}]}";
        private string callJsonAllOptions = @"{""tropo"":[{ ""call"":{""timeout"":10.0,""to"":[""3055195825""],""from"":{""id"":""3055551212""},""network"":""SMS"",""channel"":""TEXT"",""answerOnMedia"":false,""headers"":{""foo"":""bar"",""bling"":""baz""},""recording"":{""format"":""audio/mp3"",""method"":""POST"",""password"":""password"",""username"":""jose"",""url"":""http://blah.com/recordings/1234.wav""}}}]}";
        private string conferenceJson = @"{""tropo"":[{ ""conference"":{""name"":""foo"",""id"":""1234"",""mute"":false,""playTones"":false,""terminator"":""#""}}]}";
        private string messageJson = @"{""tropo"":[{ ""message"":{""say"":{""value"":""This is an announcement""},""timeout"":10.0,""to"":[""3055195825""],""from"":{""id"":""3055551212""},""network"":""SMS"",""channel"":""TEXT"",""answerOnMedia"":false,""voice"":""kate""}}]}";
        private string messageJsonAllOptions = @"{""tropo"":[{ ""message"":{""name"":""foo"",""required"":true,""say"":{""value"":""This is an announcement""},""timeout"":10.0,""to"":[""3055195825""],""from"":{""id"":""3055551212"",""channel"":""VOICE"",""name"":""unknown""},""network"":""SMS"",""channel"":""TEXT"",""answerOnMedia"":false,""voice"":""kate""}}]}";
        private string startRecordingJson = @"{""tropo"":[{ ""startRecording"":{""format"":""audio/mp3"",""method"":""POST"",""password"":""password"",""username"":""jose"",""url"":""http://blah.com/recordings/1234.wav""}}]}";

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
            tropo.ask(null, null, choices, null, "foo", null, say, null);
            Assert.AreEqual(this.askJson, TropoJSON.render(tropo));
        }
        
        [TestMethod]
        public void testAskFromObject()
        {
            Say say = new Say("Please enter your 5 digit zip code.");
            Choices choices = new Choices("[5 DIGITS]");
            Ask ask = new Ask(choices, "foo", say);

            Tropo tropo = new Tropo();
            tropo.ask(ask);
            Assert.AreEqual(this.askJson, TropoJSON.render(tropo));
        }

        [TestMethod]
        public void testAskWithOptions()
        {
            Say say = new Say("Please enter your 5 digit zip code.");
            Choices choices = new Choices("[5 DIGITS]");
            Ask ask = new Ask();
            ask.choices = choices;
            ask.name = "foo";
            ask.say = say;
            ask.timeout = 30;
            ask.required = true;
            ask.minConfidence = 30;
            ask.attempts = 1;
            ask.bargein = false;

            Tropo tropo = new Tropo();
            tropo.ask(ask);
            Assert.AreEqual(this.askJsonWithOptions, TropoJSON.render(tropo));
        }

        [TestMethod]
        public void testAskWithOptionsInDifferentOrder()
        {
            Say say = new Say("Please enter your 5 digit zip code.");
            Choices choices = new Choices("[5 DIGITS]");
            Ask ask = new Ask();
            ask.bargein = false;
            ask.choices = choices;
            ask.required = true;
            ask.attempts = 1;
            ask.name = "foo";
            ask.say = say;
            ask.timeout = 30;            
            ask.minConfidence = 30;           

            Tropo tropo = new Tropo();
            tropo.ask(ask);
            Assert.AreEqual(this.askJsonWithOptions, TropoJSON.render(tropo));
        }

        [TestMethod]
        public void testAskMethodWithAllArguements()
        {
            Tropo tropo = new Tropo();
            tropo.ask(1, false, new Choices("[5 DIGITS]"), 30, "foo", true, new Say("Please enter your 5 digit zip code."), 30);
            Assert.AreEqual(this.askJsonWithOptions, TropoJSON.render(tropo));
        }

        #endregion

        #region Call Tests

        [TestMethod]
        public void testToOnly()
        {
            ArrayList numbersToCall = new ArrayList(2);
            numbersToCall.Add("3055195825");
            numbersToCall.Add("3054445567");

            Tropo tropo = new Tropo();
            tropo.call(numbersToCall);
            Assert.AreEqual(this.callJson, TropoJSON.render(tropo));
        }

        [TestMethod]
        public void testCallUseAllOptions()
        {
            Tropo tropo = new Tropo();

            Hashtable headers = new Hashtable(2);
            headers.Add("foo", "bar");
            headers.Add("bling", "baz");

            StartRecording recording = new StartRecording(AudioFormat.mp3, Method.post, "http://blah.com/recordings/1234.wav", "jose", "password");

            tropo.call("3055195825", "3055551212", Network.sms, Channel.text, false, 10, headers, recording);
            Assert.AreEqual(this.callJsonAllOptions, TropoJSON.render(tropo));
        }

        [TestMethod]
        public void testCallUsingCallObject()
        {

            Tropo tropo = new Tropo();

            Hashtable headers = new Hashtable();
            headers.Add("foo", "bar");
            headers.Add("bling", "baz");

            StartRecording recording = new StartRecording(AudioFormat.mp3, Method.post, "http://blah.com/recordings/1234.wav", "jose", "password");

            ArrayList to = new ArrayList(1);
            to.Add("3055195825");

            Call call = new Call();
            call.recording = recording;
            call.headers = headers;
            call.timeout = 10;
            call.answerOnMedia = false;
            call.channel = Channel.text;
            call.network = Network.sms;
            call.to = to;
            call.from = new Endpoint("3055551212", null, null, null);

            tropo.call(call);
            Assert.AreEqual(this.callJsonAllOptions, TropoJSON.render(tropo));
        }

        #endregion

        #region Conference Tests

        [TestMethod]
        public void testConference()
        {
            Tropo tropo = new Tropo();
            tropo.conference("1234", false, "foo", false, null, "#");

            Assert.AreEqual(this.conferenceJson, TropoJSON.render(tropo));
 
        }

        [TestMethod]
        public void testConferenceFromObject()
        {
            Conference conference = new Conference();
            conference.id = "1234";
            conference.mute = false;
            conference.name = "foo";
            conference.playTones = false;
            conference.terminator = "#";

            Tropo tropo = new Tropo();
            tropo.conference(conference);

            Assert.AreEqual(this.conferenceJson, TropoJSON.render(tropo));

        }

        #endregion

        #region Hangup Tests

        [TestMethod]
        public void testHangup()
        {
            Tropo tropo = new Tropo();
            tropo.hangup();
            Assert.AreEqual(@"{""tropo"":[{ ""hangup"":{}}]}", TropoJSON.render(tropo), true);
        }

        #endregion

        #region Message Tests

        [TestMethod]
        public void testMessage()
        {
            Say say = new Say("This is an announcement");
            Tropo tropo = new Tropo();
            tropo.Voice = Voice.British_English_female;
            Endpoint from = new Endpoint("3055551212", null, null, null);
            ArrayList to = new ArrayList();
            to.Add("3055195825");
            tropo.message(say, to, false, Channel.text, from, null, Network.sms, null, 10);

            Assert.AreEqual(this.messageJson, TropoJSON.render(tropo));
        }

        [TestMethod]
        public void testMessageFromObject()
        {
            Say say = new Say("This is an announcement");
            Endpoint from = new Endpoint("3055551212", null, null, null);
            Message message = new Message();
            ArrayList to = new ArrayList();
            to.Add("3055195825");
            message.say = say;
            message.to = to;
            message.from = from;
            message.answerOnMedia = false;
            message.channel = Channel.text;
            message.network = Network.sms;
            message.timeout = 10;

            Tropo tropo = new Tropo();
            tropo.Voice = Voice.British_English_female;
            tropo.message(message);

            Assert.AreEqual(this.messageJson, TropoJSON.render(tropo));
        }

        [TestMethod]
        public void testMessageUseAllOptions()
        {
            Say say = new Say("This is an announcement");
            Tropo tropo = new Tropo();
            tropo.Voice = Voice.British_English_female;
            Endpoint from = new Endpoint("3055551212", Channel.voice, "unknown", Network.pstn);
            ArrayList to = new ArrayList();
            to.Add("3055195825");
            tropo.message(say, to, false, Channel.text, from, "foo", Network.sms, true, 10);

            Assert.AreEqual(this.messageJsonAllOptions, TropoJSON.render(tropo));
        }

        #endregion

        #region Record Tests

        [TestMethod]
        public void testNewRecord()
        {
            Say say = new Say("Please say your account number");
            Choices choices = new Choices("[5 DIGITS]", null, "#");
            
            Tropo tropo = new Tropo();
            tropo.record(null, null, null, choices, AudioFormat.wav, null, null, Method.post, null, null, say, null, null, null);
        }

        [TestMethod]
        public void testNewRecordFromObject()
        {
            Say say = new Say("Please say your account number");
            Choices choices = new Choices("[5 DIGITS]", null, "#");
            Record record = new Record();
            record.choices = choices;
            record.format = AudioFormat.wav;
            record.method = Method.post;
            record.say = say;
            record.required = true;

            Tropo tropo = new Tropo();
            tropo.record(record);
            Assert.AreEqual(this.recordJson, TropoJSON.render(tropo));
        }

        [TestMethod]
        public void testNewRecordObjectWithOptionsInDifferentOrder()
        {
            Say say = new Say("Please say your account number");
            Choices choices = new Choices("[5 DIGITS]", null, "#");
            Record record = new Record();
            record.say = say;
            record.method = Method.post;
            record.choices = choices;
            record.format = AudioFormat.wav;
            record.required = true;

            Tropo tropo = new Tropo();
            tropo.record(record);
            Assert.AreEqual(this.recordJson, TropoJSON.render(tropo));
        }
        
        [TestMethod]
        public void testRecordTranscription()
        {
            Say say = new Say("Please say your account number");
            Choices choices = new Choices("[5 DIGITS]", null, "#");
            Transcription transcription = new Transcription();

            transcription.url = "http://example.com/";
            transcription.id = "foo";
            transcription.emailFormat = "encoded";

            Tropo tropo = new Tropo();
            tropo.record(1, false, true, choices, AudioFormat.wav, 5, 30, Method.post, "foo", true, say, 5, transcription, "bar", "http://example.com/"); 
            Assert.AreEqual(this.recordJsonWithTranscription, TropoJSON.render(tropo));
        }

        #endregion

        #region StartRecording Tests

        [TestMethod]
        public void testNewStartRecording()
        {
            Tropo tropo = new Tropo();
            tropo.startRecording(AudioFormat.mp3, Method.post, "http://blah.com/recordings/1234.wav", "jose", "password");

            Assert.AreEqual(this.startRecordingJson, TropoJSON.render(tropo));
        }

        [TestMethod]
        public void testNewStartRecordingObject()
        {
            StartRecording startRecording = new StartRecording();
            startRecording.format = AudioFormat.mp3;
            startRecording.method = Method.post;
            startRecording.url = "http://blah.com/recordings/1234.wav";
            startRecording.username = "jose";
            startRecording.password = "password";

            Tropo tropo = new Tropo();
            tropo.startRecording(startRecording);

            Assert.AreEqual(this.startRecordingJson, TropoJSON.render(tropo));
        }

        #endregion

    }
}
