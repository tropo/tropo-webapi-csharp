using System.Collections;

namespace TropoCSharp.Tropo
{
    /// <summary>
    /// The Base class for all Tropo actions.
    /// </summary>
    public class TropoBase
    {
        protected Choices choices;
        protected int? attempts;
        protected bool? bargein;
        protected int? minConfidence;
        protected string name;
        protected bool? required;
        protected Say say;
        protected float? timeout;
        protected ArrayList to;
        protected Endpoint from;
        protected string network;
        protected string channel;
        protected bool? answerOnMedia;
        protected Hashtable headers;
        protected StartRecording recording;
        protected string @value;
        protected string mode;
        protected string termChar;
        protected string id;
        protected bool? mute;
        protected bool? playTones;
        protected string terminator;
        protected string voice;
        protected string @event;
        protected string next;
        protected string format;
        protected float? maxSilence;
        protected float? maxTime;
        protected string method;
        protected string password;
        protected Transcription transcription;
        protected string username;
        protected string url;
        protected string uri;
        protected string @as;
        protected string emailFormat;
        protected On on;
        protected int? ringRepeat;
        protected bool? beep;
    }
}
