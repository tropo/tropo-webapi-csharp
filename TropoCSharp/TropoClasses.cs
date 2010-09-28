using System;
using System.Collections;
using Newtonsoft.Json;

namespace TropoCSharp.Tropo
{

    #region Main Tropo class

    /// <summary>
	/// Main tropo class.
	/// </summary>
	public class Tropo
	{
        // The TTS voice to use when rendering content.
        private string _voice;

        // The language to use when rendering content.
        private string _language;
        
        // An arry list to hold tropo action elements.
		public ArrayList tropo;

        /// <summary>
		/// Class constructor.
		/// </summary>
		public Tropo () 
		{
			this.tropo = new ArrayList();
		}

        /// <summary>
        /// Set a default voice for use with all Text To Speech.
        /// </summary>
        public string Voice
        {
            get { return _voice; }
            set { _voice = value; }
        }

        /// <summary>
        /// Set a default language to use in speech recognition.
        /// </summary>
        public string Language
        {
            get { return _language; }
            set { _language = value; }
        }
        
        /// <summary>
        /// Sends a prompt to the user and optionally waits for a response. 
        /// </summary>
        /// <param name="attempts">How many times the caller can attempt input before an error is thrown.</param>
        /// <param name="bargein">Should the user be allowed to barge in before TTS is complete?</param>
        /// <param name="choices">The grammar to use in recognizing and validating input.</param>
        /// <param name="minConfidence">How confident should Tropo be in a speech recognition match?</param>
        /// <param name="name">identifies the return value of an ask, so you know the context for the returned information.</param>
        /// <param name="required">Is input required here?</param>
        /// <param name="say">This determines what is played or sent to the caller.</param>
        /// <param name="timeout">The amount of time Tropo will wait, in seconds, after sending or playing the prompt for the user to begin a response.</param>
        public void ask(int? attempts, bool? bargein, Choices choices, int? minConfidence, string name, bool? required, Say say, float? timeout)
		{
			Ask ask = new Ask();
			ask.attempts = attempts;
			ask.bargein = bargein;
			ask.choices = choices;
			ask.minConfidence = minConfidence;
			ask.name = name;
			ask.required = required;

            if(!String.IsNullOrEmpty(this.Voice))
            {
                say.voice = this.Voice;
            }

			ask.say = say;
			ask.timeout = timeout;

            serialize(ask, "ask");			
		}

        /// <summary>
        /// Overload method for Ask that allows an array of events to be used.
        /// </summary>
        /// <param name="attempts">How many times the caller can attempt input before an error is thrown.</param>
        /// <param name="bargein">Should the user be allowed to barge in before TTS is complete?</param>
        /// <param name="choices">The grammar to use in recognizing and validating input</param>
        /// <param name="minConfidence">How confident should Tropo be in a speech reco match?</param>
        /// <param name="name">Identifies the return value of an Ask, so you know the context for the returned information.</param>
        /// <param name="required">Is input required here?</param>
        /// <param name="say">This determines what is played or sent to the caller.</param>
        /// <param name="timeout">The amount of time Tropo will wait, in seconds, after sending or playing the prompt for the user to begin a response.</param>
        /// <param name="events">??</param>
        public void ask(int? attempts, bool? bargein, Choices choices, int? minConfidence, string name, bool? required, Say say, float? timeout, Array events)
        {
            Ask ask = new Ask();
            ask.attempts = attempts;
            ask.bargein = bargein;
            ask.choices = choices;
            ask.minConfidence = minConfidence;
            ask.name = name;
            ask.required = required;

            if (!String.IsNullOrEmpty(this.Voice))
            {
                say.voice = this.Voice;
            }

            ask.say = say;
            ask.timeout = timeout;

            serialize(ask, "ask");

            // TODO: How is the events array supposed to be added to the Tropo object?
        }

        /// <summary>
        /// Overload for Ask that allows an Ask object to be passed.
        /// </summary>
        /// <param name="ask">An Ask object.</param>
        public void ask(Ask ask)
        {
            this.ask(ask.attempts, ask.bargein, ask.choices, ask.minConfidence, ask.name, ask.required, ask.say, ask.timeout);
        }

        /// <summary>
        /// Places a call or sends an an IM, Twitter, or SMS message. To start a call, use the Session API to tell Tropo to launch your code.
        /// </summary>
        /// <param name="to">An ArryList containing recipients to call.</param>
        /// <param name="from">An Endpoint object representing who the call is from.</param>
        /// <param name="network">Network is used mainly by the text channels; values can be SMS when sending a text message, or a valid IM network name such as AIM, MSN, JABBER, YAHOO and GTALK.</param>
        /// <param name="channel">This defines the channel used to place new calls.</param>
        /// <param name="answerOnMedia">If this is set to true, the call will be considered "answered" and audio will begin playing as soon as media is received from the far end </param>
        /// <param name="timeout">The amount of time Tropo will wait, in seconds, after sending or playing the prompt for the user to begin a response.</param>
        /// <param name="headers">This contains the Session Initiation Protocol (SIP) Headers for the current session.</param>
        /// <param name="recording">This is a shortcut to allow you to start call recording as soon as the call is answered. </param>      
        public void call(ArrayList to, Endpoint from, string network, string channel, bool? answerOnMedia, float? timeout, Hashtable headers, StartRecording recording)
        {
            Call call = new Call();
            call.to = to;
            call.from = from;
            call.network = network;
            call.channel = channel;
            call.answerOnMedia = answerOnMedia;
            call.timeout = timeout;
            call.headers = headers;
            call.recording = recording;

            serialize(call, "call");       
        }

        /// <summary>
        /// Overload for Call that allows the To parameter to be passed as a String.
        /// </summary>
        /// <param name="to">A String containing the recipient to call.</param>
        /// <param name="from">An Endpoint object representing who the call is from.</param>
        /// <param name="network">Network is used mainly by the text channels; values can be SMS when sending a text message, or a valid IM network name such as AIM, MSN, JABBER, YAHOO and GTALK.</param>
        /// <param name="channel">This defines the channel used to place new calls.</param>
        /// <param name="answerOnMedia">If this is set to true, the call will be considered "answered" and audio will begin playing as soon as media is received from the far end.</param>
        /// <param name="timeout">The amount of time Tropo will wait, in seconds, after sending or playing the prompt for the user to begin a response.</param>
        /// <param name="headers">This contains the Session Initiation Protocol (SIP) Headers for the current session.</param>
        /// <param name="recording">This is a shortcut to allow you to start call recording as soon as the call is answered. </param>      
        public void call(String to, string from, string network, string channel, bool? answerOnMedia, float? timeout, Hashtable headers, StartRecording recording)
        {
            Call call = new Call();
            ArrayList _to = new ArrayList();
            _to.Add(to);
            call.to = _to;
            call.from = new Endpoint(from, null, null, null);
            call.network = network;
            call.channel = channel;
            call.answerOnMedia = answerOnMedia;
            call.timeout = timeout;
            call.headers = headers;
            call.recording = recording;

            serialize(call, "call");
        }

        /// <summary>
        /// Overload for Call that allows one parameter.
        /// </summary>
        /// <param name="to">The number of the person to call.</param>
        public void call(String to)
        {
            Call call = new Call(to);
            serialize(call, "call");
        }

        /// <summary>
        /// Overload for call that allows multiple calls to be made with one parmameter.
        /// </summary>
        /// <param name="to">An ArryList containing recipients to call.</param>
        public void call(ArrayList to)
        {
            Call call = new Call(to);
            serialize(call, "call");
        }

        /// <summary>
        /// Overload for call that allows a Call object to be passed.
        /// </summary>
        /// <param name="call">A Call object.</param>
        public void call(Call call)
        {
            this.call(call.to, call.from, call.network, call.channel, call.answerOnMedia, call.timeout, call.headers, call.recording);
        }

        /// <summary>
        /// This object allows multiple lines in separate sessions to be conferenced together so that the parties on each line can talk to each other simultaneously.
        /// This is a voice channel only feature. 
        /// </summary>
        /// <param name="id">This defines the id/name of the conference room to create.</param>
        /// <param name="mute">Adds the user to the conference room with their audio muted.</param>
        /// <param name="name">Identifies the return value of a Conference, so you know the context for the returned information.</param>
        /// <param name="playTones">This defines whether to send touch tone phone input to the conference or block the audio.</param>
        /// <param name="required">Determines whether Tropo should move on to the next action.</param>
        /// <param name="terminator">This is the touch-tone key (also known as "DTMF digit") used to exit the conference.</param>
        public void conference(string id, bool? mute, string name, bool? playTones, bool? required, string terminator)
        {
            Conference conference = new Conference();
            conference.id = id;
            conference.mute = mute;
            conference.name = name;
            conference.playTones = playTones;
            conference.required = required;
            conference.terminator = terminator;

            serialize(conference, "conference");
        }

        /// <summary>
        /// Overload for Conference that allows a Conference object to be passed.
        /// </summary>
        /// <param name="conference">A Conference object.</param>
        public void conference(Conference conference)
        {
            this.conference(conference.id, conference.mute, conference.name, conference.playTones, conference.required, conference.terminator);
        }

        /// <summary>
        /// This function instructs Tropo to "hang-up" or disconnect the session associated with the current session.
        /// </summary>
        public void hangup()
        {
            Hangup hangup = new Hangup();
            serialize(hangup, "hangup");
        }

        /// <summary>
        /// A shortcut method to create a session, say something, and hang up, all in one step. 
        /// This is particularly useful for sending out a quick SMS or IM. 
        /// </summary>
        /// <param name="say">This determines what is played or sent to the caller.</param>
        /// <param name="to">The destination to make a call to or send a message to.</param>
        /// <param name="answerOnMedia">If this is set to true, the call will be considered "answered" and audio will begin playing as soon as media is received from the far end.</param>
        /// <param name="channel">This defines the channel used to place new calls.</param>
        /// <param name="from">An Endpoint object representing who the call is from.</param>
        /// <param name="name">Identifies the return value of a Message, so you know the context for the returned information.</param>
        /// <param name="network">Network is used mainly by the text channels; values can be SMS when sending a text message, or a valid IM network name such as AIM, MSN, JABBER, YAHOO and GTALK.</param>
        /// <param name="required">Determines whether Tropo should move on to the next action.</param>
        /// <param name="timeout">The amount of time Tropo will wait, in seconds, after sending or playing the prompt for the user to begin a response.</param>
        public void message(Say say, ArrayList to, bool? answerOnMedia, string channel, Endpoint from, string name, string network, bool? required, float? timeout)
        {
            Message message = new Message();
            message.say = say;
            message.to = to;
            message.answerOnMedia = answerOnMedia;
            message.channel = channel;
            message.from = from;
            message.name = name;
            message.network = network;
            message.required = required;
            message.timeout = timeout;
            message.voice = String.IsNullOrEmpty(this.Voice) ? null : this.Voice;

            serialize(message, "message");
        }

        /// <summary>
        /// Overload for Message that allows a Message object to be passed.
        /// </summary>
        /// <param name="message">A Message object.</param>
        public void message(Message message)
        {           
            this.message(message.say, message.to, message.answerOnMedia, message.channel, message.from, message.name, message.network, message.required, message.timeout);
        }

        /// <summary>
        /// Adds an event callback so that your application may be notified when a particular event occurs.
        /// </summary>
        /// <param name="event">This defines which event the on action handles.</param>
        /// <param name="next">When an associated event occurs, Tropo will post to the URL defined here. If left blank, Tropo will simply hangup.</param>
        /// <param name="say">This determines what is played or sent to the caller.</param>      
        public void on(string @event, string next, Say say)
		{
			On on = new On();
			on.@event = @event;
			on.next = next;
			on.say = say;

            serialize(on, "on");
        }

        /// <summary>
        /// Overload for On that allows an On object to be passed.
        /// </summary>
        /// <param name="on">An On object.</param>
        public void on(On on)
        {
            this.on(on.@event, on.next, on.say);
        }

        /// <summary>
        /// Plays a prompt (audio file or text to speech) and optionally waits for a response from the caller that is recorded.
        /// If collected, responses may be in the form of DTMF or speech recognition using a simple grammar format defined below.
        /// The record funtion is really an alias of the prompt function, but one which forces the record option to true regardless of how it is (or is not) initially set.
        /// At the conclusion of the recording, the audio file may be automatically sent to an external server via FTP or an HTTP POST/Multipart Form.
        /// If specified, the audio file may also be transcribed and the text returned to you via an email address or HTTP POST/Multipart Form.
        /// </summary>
        /// <param name="attempts">How many times the caller can attempt input before an error is thrown.</param>
        /// <param name="bargein">Should the user be allowed to barge in before TTS is complete?</param>
        /// <param name="beep">When set to true, callers will hear a tone indicating the recording has begun.</param>
        /// <param name="choices">The grammar to use in recognizing and validating input.</param>
        /// <param name="format">This specifies the format for the audio recording.</param>
        /// <param name="maxSilence">The maximum amount of time, in seconds, to wait for silence after a user stops speaking.</param>
        /// <param name="maxTime">The maximum amount of time, in seconds, the user is allotted for input.</param>
        /// <param name="method">This defines how you want to send the audio file.</param>
        /// <param name="password">This identifies the FTP account password.</param>
        /// <param name="required">Determines whether Tropo should move on to the next action.</param>
        /// <param name="say">This determines what is played or sent to the caller.</param>
        /// <param name="timeout">The amount of time Tropo will wait, in seconds, after sending or playing the prompt for the user to begin a response.</param>
        /// <param name="username">This identifies the FTP account username.</param>
        /// <param name="url">This is the destination URL to send the recording.</param>
        public void record(int? attempts, bool? bargein, bool? beep, Choices choices, string format, float? maxSilence, float? maxTime, string method, string password, bool? required, Say say, float? timeout, string username, string url)
        {
            Record record = new Record();
            record.attempts = attempts;
            record.bargein = bargein;
            record.beep = beep;
            record.choices = choices;
            record.format = format;
            record.maxSilence = maxSilence;
            record.maxTime = maxTime;
            record.method = method;
            record.password = password;
            record.required = required;
            record.say = say;
            record.timeout = timeout;
            record.url = url;
            record.username = username;

            serialize(record, "record");
        }


        /// <summary>
        /// Overload for Record that allows a Transcription object to be passed.
        /// </summary>
        /// <param name="attempts">How many times the caller can attempt input before an error is thrown.</param>
        /// <param name="bargein">Should the user be allowed to barge in before TTS is complete?</param>
        /// <param name="beep">When set to true, callers will hear a tone indicating the recording has begun.</param>
        /// <param name="choices">The grammar to use in recognizing and validating input.</param>
        /// <param name="format">This specifies the format for the audio recording.</param>
        /// <param name="maxSilence">The maximum amount of time, in seconds, to wait for silence after a user stops speaking.</param>
        /// <param name="maxTime">The maximum amount of time, in seconds, the user is allotted for input.</param>
        /// <param name="method">This defines how you want to send the audio file.</param>
        /// <param name="password">This identifies the FTP account password.</param>
        /// <param name="required">Determines whether Tropo should move on to the next action.</param>
        /// <param name="say">This determines what is played or sent to the caller.</param>
        /// <param name="timeout">The amount of time Tropo will wait, in seconds, after sending or playing the prompt for the user to begin a response.</param>
        /// <param name="transcription">This allows you to submit a recording to be transcribed and specifies where to send the transcription.</param>
        /// <param name="username">This identifies the FTP account username.</param>
        /// <param name="url">This is the destination URL to send the recording.</param>
        public void record(int? attempts, bool? bargein, bool? beep, Choices choices, string format, float? maxSilence, float? maxTime, string method, string password, bool? required, Say say, float? timeout, Transcription transcription, string username, string url)
        {
            Record record = new Record();
            record.attempts = attempts;
            record.bargein = bargein;
            record.beep = beep;
            record.choices = choices;
            record.format = format;
            record.maxSilence = maxSilence;
            record.maxTime = maxTime;
            record.method = method;
            record.password = password;
            record.required = required;
            record.say = say;
            record.timeout = timeout;
            record.transcription = transcription;
            record.url = url;
            record.username = username;

            serialize(record, "record");
        }

        /// <summary>
        /// Overload for Record that allows a Record object to be passed.
        /// </summary>
        /// <param name="record">A Record object.</param>
        public void record(Record record)
        {
            this.record(record.attempts, record.bargein, record.beep, record.choices, record.format, record.maxSilence, record.maxTime, record.method, record.password, record.required, record.say, record.timeout, record.username, record.url);
        }

        /// <summary>
        /// The redirect function forwards an incoming call to another destination / phone number before answering it.
        /// The redirect function must be called before answer is called; redirect expects that a call be in the ringing or answering state.
        /// Use transfer when working with active answered calls. 
        /// </summary>
        /// <param name="to">The SIP destination for the incoming call, as a URL.</param>
        /// <param name="name">Identifies the return value of a Redirect, so you know the context for the returned information.</param>
        /// <param name="required">Determines whether Tropo should move on to the next action.</param>
        public void redirect(ArrayList to, string name, bool? required)
        {
            Redirect redirect = new Redirect();
            redirect.to = to;
            redirect.name = name;
            redirect.required = required;

            serialize(redirect, "redirect");

        }

        /// <summary>
        /// Overload for Redirect that allow a Redirect object to be passed.
        /// </summary>
        /// <param name="redirect">A Redirect object.</param>
        public void redirect(Redirect redirect)
        {
            this.redirect(redirect.to, redirect.name, redirect.required);
        }

        /// <summary>
        /// Allows Tropo applications to reject incoming sessions before they are answered. 
        /// </summary>
        public void reject()
        {
            Reject reject = new Reject();
            serialize(reject, "reject");

        }

		/// <summary>
		/// When the current session is a voice channel this key will either play a message or an audio file from a URL.
        /// In the case of an text channel it will send the text back to the user via i nstant messaging or SMS. 
		/// </summary>
        /// <param name="value">This defines what the user will hear when the action is executed. </param>
        /// <param name="as">This specifies the type of data being spoken, so the TTS Engine can interpret it correctly.</param>
        /// <param name="name">Identifies the return value of a Say, so you know the context for the returned information.</param>
        /// <param name="required">Determines whether Tropo should move on to the next action.</param>
        public void say(string @value, string @as, string name, bool? required)
		{
			Say say = new Say();
			say.@value = @value;
			say.@as = @as;
			say.name = name;
			say.required = required;
            say.voice = String.IsNullOrEmpty(this.Voice) ? null : this.Voice;

            serialize(say, "say");
		}

        /// <summary>
        /// Overload method for Say that allows only a string value to be passed.
        /// </summary>
        /// <param name="value">The prompt to say or send to the user.</param>
        public void say(string @value)
        {
            this.say(value, null, null, null);
        }

        /// <summary>
        /// Overload method for Say that allows a Say object to be passed directly.
        /// </summary>
        /// <param name="say">A Say object.</param>
        public void say(Say say)
        {
            this.say(say.value, say.@as, say.name, (bool)say.required);
        }

        /// <summary>
        /// Ooverload method for Say that allows an arrat of prompts to be used.
        /// </summary>
        /// <param name="says">The prompts to say or send to the caller.</param>
        public void say(Array says)
        {
            ArrayList saysToAdd = new ArrayList();
            foreach (string element in says)
            {
                Say say = new Say();
                say.value = element;
                say.@as = null;
                say.name = null;
                say.required = true;

                saysToAdd.Add(say);                
            }

            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.DefaultValueHandling = DefaultValueHandling.Ignore;
            this.tropo.Add("{ \"say\":" + JsonConvert.SerializeObject(saysToAdd, Formatting.None, settings) + "}");

        }

        /// <summary>
        /// Allows Tropo applications to begin recording the current session.
        /// The resulting recording may then be sent via FTP or an HTTP POST/Multipart Form. 
        /// </summary>
        /// <param name="format">This specifies the format for the audio recording; it can be 'audio/wav' or 'audio/mp3'.</param>
        /// <param name="method">This defines how you want to send the audio file.</param>
        /// <param name="url">This is the destination URL to send the recording.</param>
        /// <param name="username">This identifies the FTP account username.</param>
        /// <param name="password">This identifies the FTP account password.</param>
        public void startRecording(string format, string method, string url, string username, string password)
        {
            StartRecording startRecording = new StartRecording();
            startRecording.format = format;
            startRecording.method = method;
            startRecording.url = url;
            startRecording.username = username;
            startRecording.password = password;

            serialize(startRecording, "startRecording");
        }

        /// <summary>
        /// Overload for StartRecording that allows a a StartRecording object to be passed directly. 
        /// </summary>
        /// <param name="startRecording">A StartRecording object.</param>
        public void startRecording(StartRecording startRecording)
        {
            this.startRecording(startRecording.format, startRecording.method, startRecording.url, startRecording.username, startRecording.password);
        }

        /// <summary>
        /// Stops a previously started recording.
        /// </summary>
        public void stopRecording()
        {
            StopRecording stopRecording = new StopRecording();
            serialize(stopRecording, "stopRecording");
        }

        /// <summary>
        /// Transfers an already answered call to another destination / phone number.
        /// Call may be transferred to another phone number or SIP address, which is set through the "to" parameter and is in URL format.
        /// </summary>
        /// <param name="answerOnMedia">If this is set to true, the call will be considered "answered" and audio will begin playing as soon as media is received from the far end.</param>
        /// <param name="choices">The grammar to use in recognizing and validating input.</param>
        /// <param name="from">An Endpoint object representing who the call is from.</param>
        /// <param name="on">An On object.</param>
        /// <param name="ringRepeat">The number of rings to allow on the outbound call attempt.</param>
        /// <param name="timeout">The amount of time Tropo will wait, in seconds, after sending or playing the prompt for the user to begin a response.</param>
        /// <param name="to">The new destination for the incoming call as a URL.</param>
        public void transfer(bool? answerOnMedia, Choices choices, Endpoint from, On on, int? ringRepeat, float? timeout, ArrayList to)
        {
            Transfer transfer = new Transfer();
            transfer.answerOnMedia = answerOnMedia;
            transfer.choices = choices;
            transfer.from = from;
            transfer.on = on;
            transfer.ringRepeat = ringRepeat;
            transfer.timeout = timeout;
            transfer.to = to;

            serialize(transfer, "transfer");
        }

        /// <summary>
        /// Overload for Transfer that allows a Transfer object to be passed directly.
        /// </summary>
        /// <param name="transfer">A Transfer object.</param>
        public void transfer(Transfer transfer)
        {
            this.transfer(transfer.answerOnMedia, transfer.choices, transfer.from, transfer.on, transfer.ringRepeat, transfer.timeout, transfer.to);
        }

        /// <summary>
        /// Method to serialize Tropo action objects and add to the base Tropo array.
        /// </summary>
        /// <param name="action"></param>
        /// <param name="prefix"></param>
        private void serialize(TropoBase action, string prefix)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.DefaultValueHandling = DefaultValueHandling.Ignore;
            this.tropo.Add("{ \"" + prefix + "\":" + JsonConvert.SerializeObject(action, Formatting.None, settings) + "}");
        }
    }

    #endregion

    #region Tropo Action Classes

    /// <summary>
    /// Ask is essentially a say that requires input; it requests information from the caller and waits for a response.
	/// </summary>
    public class Ask : TropoBase
	{
        public Ask()
        {
        }
        
        public Ask(Choices choices, string name, Say say)
        {
            this.choices = choices;
            this.name = name;
            this.say = say;
        }
	}

    /// <summary>
    /// Initiates an outbound call or a text conversation. Note that this action is only valid when there is no active WebAPI call.
    /// </summary>
    public class Call : TropoBase
    {
        public Call()
        {
        }

        public Call(String to)
        {
            this.to = new ArrayList();
            this.to.Add(to);
        }

        public Call(ArrayList to)
        {
            this.to = to;
        }
    }

    /// <summary>
    /// The grammar to use in recognizing and validating input.
    /// </summary>
    public class Choices : TropoBase
    {
        public Choices()
        {
        }

        public Choices(string @value)
        {
            this.@value = @value;
        }

        public Choices(string @value, string mode, string termChar)
        {
            this.value = @value;
            this.mode = mode;
            this.termChar = termChar;
        }
    }

    /// <summary>
    /// This action allows multiple lines in separate sessions to be conferenced together so that the parties on each line can talk to each other simultaneously.
    /// </summary>
    public class Conference : TropoBase
    {
    }

    /// <summary>
    /// This action instructs Tropo to "hang-up" or disconnect the session associated with the current session. 
    /// </summary>
    public class Hangup : TropoBase
    {
    }

    /// <summary>
    /// Creates a call, says something and then hangs up, all in one step. This is particularly useful for sending out a quick SMS or IM. 
    /// </summary>
    public class Message : TropoBase
    {
    }

    /// <summary>
    /// This action determines the event(s) to be handled. 
    /// </summary>
    public class On : TropoBase
    {

        public On()
        {
        }

        public On(string @event, string next, Say say)
        {
            this.@event = @event;
            this.next = next;
            this.say = say;
        }
    }

    /// <summary>
    /// Plays a prompt (audio file or text to speech) then optionally waits for a response from the caller and records it.
    /// </summary>
    public class Record : TropoBase
    {
    }

    /// <summary>
    /// This is used to deflect the call to a third party SIP address. This action must be called before the call is answered.
    /// </summary>
    public class Redirect : TropoBase
    {
    }

    /// <summary>
    /// Reject an incoming call.
    /// </summary>
    public class Reject : TropoBase
    {
    }
	
	/// <summary>
	/// When the current session is a voice channel this key will either play a message or an audio file from a URL. 
	/// In the case of an text channel it will send the text back to the user via instant messaging or SMS.
	/// </summary>
    public class Say : TropoBase
	{

        public Say()
        {
        }

        public Say(string @value)
        {
            this.value = @value;
        }
	}

    /// <summary>
    /// Allows Tropo applications to begin recording the current session. 
    /// </summary>
    public class StartRecording : TropoBase
    {

        public StartRecording()
        {
        }

        public StartRecording(string format, string method, string url, string username, string password)
        {
            this.format = format;
            this.method = method;
            this.url = url;
            this.username = username;
            this.password = password;
        }
    }

    /// <summary>
    /// This action stops the recording of the current call after startCallRecording has been called. 
    /// </summary>
    public class StopRecording : TropoBase
    {
    }

    /// <summary>
    /// Transcribes spoken text.
    /// </summary>
    public class Transcription : TropoBase
    {
    }

    /// <summary>
    /// This will transfer an already answered call to another destination / phone number. 
    /// </summary>
    public class Transfer : TropoBase
    {
    }

    #endregion

    #region Helper Classes

    /// <summary>
    /// A utility class to render a Tropo object as JSON.
    /// </summary>
    public static class TropoJSON
    {
        public static string render(Tropo tropo)
        {
            tropo.Language = null;
            tropo.Voice = null;
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.DefaultValueHandling = DefaultValueHandling.Ignore;
            return JsonConvert.SerializeObject(tropo, Formatting.None, settings).Replace("\\", "").Replace("\"{", "{").Replace("}\"", "}");
        }
    }
    
    /// <summary>
    /// Defnies an endoint for transfer and redirects.
    /// </summary>
    public class Endpoint
    {
        public string to;
        public string id;
        public string channel;
        public string name;
        public string network;

        public Endpoint()
        {
        }

        public Endpoint(string id, string channel, string name, string network)
        {
            this.id = id;
            this.channel = channel;
            this.name = name;
            this.id = id;
        }

        public Endpoint(string to)
        {
            this.to = to;
        }
    }

    #endregion
}
