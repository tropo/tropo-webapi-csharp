using System;
using System.Collections;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace TropoCSharp.Tropo
{

    /// <summary>
    /// Ask is essentially a say that requires input; it requests information from the caller and waits for a response.
    /// </summary>
    public class Ask : TropoBase
    {
        [JsonProperty(PropertyName = "attempts")]
        public int? Attempts { get; set; }

        [JsonProperty(PropertyName = "allowSignals")]
        public Array allowSignals { get; set; }

        [JsonProperty(PropertyName = "bargein")]
        public bool? Bargein { get; set; }

        [JsonProperty(PropertyName = "interdigitTimeout")]
        public int? InterdigitTimeout { get; set; }

        [JsonProperty(PropertyName = "minConfidence")]
        public int? MinConfidence { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "recognizer")]
        public string Recognizer { get; set; }

        [JsonProperty(PropertyName = "required")]
        public bool? Required { get; set; }

        [JsonProperty(PropertyName = "choices")]
        public Choices Choices { get; set; }

        [JsonProperty(PropertyName = "say")]
        public Say Say { get; set; }
        
        [JsonProperty(PropertyName = "sensitivity")]
        public int? Sensitivity { get; set; }

        [JsonProperty(PropertyName = "speechCompleteTimeout")]
        public float? SpeechCompleteTimeout { get; set; }

        [JsonProperty(PropertyName = "speechIncompleteTimeout")]
        public float? SpeechIncompleteTimeout { get; set; }

        [JsonProperty(PropertyName = "timeout")]
        public float? Timeout { get; set; }

        [JsonProperty(PropertyName = "voice")]
        public string Voice { get; set; }

        public Ask()
        {
        }

        public Ask(Choices choices, string name, Say say)
        {
            Choices = choices;
            Name = name;
            Say = say;
        }
    }

    /// <summary>
    /// Initiates an outbound call or a text conversation. Note that this action is only valid when there is no active WebAPI call.
    /// </summary>
    public class Call : TropoBase
    {
        [JsonProperty(PropertyName = "to")]
        public IEnumerable<String> To { get; set; }

        [JsonProperty(PropertyName = "from")]
        public string From { get; set; }

        [JsonProperty(PropertyName = "network")]
        public string Network { get; set; }

        [JsonProperty(PropertyName = "channel")]
        public string Channel { get; set; }

        [JsonProperty(PropertyName = "answerOnMedia")]
        public bool? AnswerOnMedia { get; set; }

        [JsonProperty(PropertyName = "allowSignals")]
        public Array allowSignals { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "headers")]
        public IDictionary<String, String> Headers { get; set; }

        [JsonProperty(PropertyName = "recording")]
        public StartRecording Recording { get; set; }

        [JsonProperty(PropertyName = "required")]
        public bool? Required { get; set; }

        [JsonProperty(PropertyName = "timeout")]
        public float? Timeout { get; set; }

        public Call()
        {
        }

        public Call(String to)
        {
            To = new List<String> {to};
        }

        public Call(IEnumerable<String> to)
        {
            To = to;
        }
    }

    /// <summary>
    /// The grammar to use in recognizing and validating input.
    /// </summary>
    public class Choices : TropoBase
    {
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        [JsonProperty(PropertyName = "mode")]
        public string Mode { get; set; }

        [JsonProperty(PropertyName = "terminator")]
        public string Terminator { get; set; }

        public Choices()
        {
        }

        public Choices(string @value)
        {
            Value = @value;
        }

        public Choices(string @value, string mode, string terminator)
        {
            Value = @value;
            Mode = mode;
            Terminator = terminator;
        }
    }

    /// <summary>
    /// This action allows multiple lines in separate sessions to be conferenced together so that the parties on each line can talk to each other simultaneously.
    /// </summary>
    public class Conference : TropoBase
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "allowSignals")]
        public Array allowSignals { get; set; }
        
        [JsonProperty(PropertyName = "interdigitTimeout")]
        public int? InterdigitTimeout { get; set; }

        [JsonProperty(PropertyName = "mute")]
        public bool? Mute { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "playTones")]
        public bool? PlayTones { get; set; }

        [JsonProperty(PropertyName = "terminator")]
        public string Terminator { get; set; }

        [JsonProperty(PropertyName = "required")]
        public bool? Required { get; set; }

        public Conference()
        {
        }
    }

    /// <summary>
    /// This action instructs Tropo to "hang-up" or disconnect the session associated with the current session. 
    /// </summary>
    public class Hangup : TropoBase
    {
        public Hangup()
        {
        }
    }

    /// <summary>
    /// Creates a call, says something and then hangs up, all in one step. This is particularly useful for sending out a quick SMS or IM. 
    /// </summary>
    public class Message : TropoBase
    {
        [JsonProperty(PropertyName = "say")]
        public Say Say { get; set; }

        [JsonProperty(PropertyName = "to")]
        public IEnumerable<String> To { get; set; }

        [JsonProperty(PropertyName = "from")]
        public string From { get; set; }

        [JsonProperty(PropertyName = "network")]
        public string Network { get; set; }

        [JsonProperty(PropertyName = "channel")]
        public string Channel { get; set; }

        [JsonProperty(PropertyName = "answerOnMedia")]
        public bool? AnswerOnMedia { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "required")]
        public bool? Required { get; set; }

        [JsonProperty(PropertyName = "timeout")]
        public float? Timeout { get; set; }

        [JsonProperty(PropertyName = "voice")]
        public string Voice { get; set; }

        public Message()
        {
        }
    }

    /// <summary>
    /// This action determines the event(s) to be handled. 
    /// </summary>
    public class On : TropoBase
    {
        [JsonProperty(PropertyName = "event")]
        public string Event { get; set; }

        [JsonProperty(PropertyName = "next")]
        public string Next { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "required")]
        public bool? Required { get; set; }

        [JsonProperty(PropertyName = "say")]
        public Say Say { get; set; }

        public On()
        {
        }

        public On(string @event, string next, Say say)
        {
            Event = @event;
            Next = next;
            Say = say;
        }
    }

    /// <summary>
    /// Plays a prompt (audio file or text to speech) then optionally waits for a response from the caller and records it.
    /// </summary>
    public class Record : TropoBase
    {
        [JsonProperty(PropertyName = "attempts")]
        public int? Attempts { get; set; }

        [JsonProperty(PropertyName = "allowSignals")]
        public Array allowSignals { get; set; }

        [JsonProperty(PropertyName = "bargein")]
        public bool? Bargein { get; set; }

        [JsonProperty(PropertyName = "beep")]
        public bool? Beep { get; set; }

        [JsonProperty(PropertyName = "choices")]
        public Choices Choices { get; set; }

        [JsonProperty(PropertyName = "format")]
        public string Format { get; set; }

        [JsonProperty(PropertyName = "maxSilence")]
        public float? MaxSilence { get; set; }

        [JsonProperty(PropertyName = "maxTime")]
        public float? MaxTime { get; set; }

        [JsonProperty(PropertyName = "method")]
        public string Method { get; set; }

        [JsonProperty(PropertyName = "minConfidence")]
        public int? MinConfidence { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "required")]
        public bool? Required { get; set; }

        [JsonProperty(PropertyName = "say")]
        public Say Say { get; set; }

        [JsonProperty(PropertyName = "timeout")]
        public float? Timeout { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "transcription")]
        public Transcription Transcription { get; set; }

        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "voice")]
        public string Voice { get; set; }

        public Record()
        {
        }
    }

    /// <summary>
    /// This is used to deflect the call to a third party SIP address. This action must be called before the call is answered.
    /// </summary>
    public class Redirect : TropoBase
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "required")]
        public bool? Required { get; set; }

        [JsonProperty(PropertyName = "to")]
        public IEnumerable<String> To { get; set; }

        public Redirect()
        {
        }
    }

    /// <summary>
    /// Reject an incoming call.
    /// </summary>
    public class Reject : TropoBase
    {
        public Reject()
        {
        }
    }

    /// <summary>
    /// When the current session is a voice channel this key will either play a message or an audio file from a URL. 
    /// In the case of an text channel it will send the text back to the user via instant messaging or SMS.
    /// </summary>
    public class Say : TropoBase
    {
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        [JsonProperty(PropertyName = "allowSignals")]
        public Array allowSignals { get; set; }

        [JsonProperty(PropertyName = "as")]
        public string As { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "required")]
        public bool? Required { get; set; }

        [JsonProperty(PropertyName = "voice")]
        public string Voice { get; set; }

        public Say()
        {
        }

        public Say(string @value)
        {
            Value = @value;
        }
    }

    /// <summary>
    /// Allows Tropo applications to begin recording the current session. 
    /// </summary>
    public class StartRecording : TropoBase
    {
        [JsonProperty(PropertyName = "format")]
        public string Format { get; set; }

        [JsonProperty(PropertyName = "method")]
        public string Method { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        public StartRecording()
        {
        }

        public StartRecording(string format, string method, string url, string username, string password)
        {
            Format = format;
            Method = method;
            Url = url;
            Username = username;
            Password = password;
        }
    }

    /// <summary>
    /// This action stops the recording of the current call after startCallRecording has been called. 
    /// </summary>
    public class StopRecording : TropoBase
    {
        public StopRecording()
        {
        }
    }

    /// <summary>
    /// Transcribes spoken text.
    /// </summary>
    public class Transcription : TropoBase
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; set; }

        [JsonProperty(PropertyName = "emailFormat")]
        public string EmailFormat { get; set; }

        public Transcription()
        {
        }
    }

    /// <summary>
    /// This will transfer an already answered call to another destination / phone number. 
    /// </summary>
    public class Transfer : TropoBase
    {
        [JsonProperty(PropertyName = "to")]
        public IEnumerable<String> To { get; set; }

        [JsonProperty(PropertyName = "from")]
        public string From { get; set; }

        [JsonProperty(PropertyName = "answerOnMedia")]
        public bool? AnswerOnMedia { get; set; }

        [JsonProperty(PropertyName = "allowSignals")]
        public Array allowSignals { get; set; }

        [JsonProperty(PropertyName = "choices")]
        public Choices Choices { get; set; }

        [JsonProperty(PropertyName = "headers")]
        public IDictionary<String, String> Headers { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "on")]
        public On On { get; set; }

        [JsonProperty(PropertyName = "required")]
        public bool? Required { get; set; }

        [JsonProperty(PropertyName = "terminator")]
        public string Terminator { get; set; }

        [JsonProperty(PropertyName = "timeout")]
        public float? Timeout { get; set; }

        public Transfer()
        {
        }
    }

    /// <summary>
    /// Defnies an endoint for transfer and redirects.
    /// </summary>
    public class Endpoint
    {
        [JsonProperty(PropertyName = "to")]
        public string To { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "channel")]
        public string Channel { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "network")]
        public string Network { get; set; }

        public Endpoint()
        {
        }

        public Endpoint(string id, string channel, string name, string network)
        {
            Id = id;
            Channel = channel;
            Name = name;
            Network = network;
        }

        public Endpoint(string to)
        {
            To = to;
        }
    }
}
