using System.Collections;

namespace TropoCSharp.Tropo
{
    /// <summary>
    /// The Base class for all Tropo actions.
    /// </summary>
    public class TropoBase
    {
        public Choices choices;
        public int? attempts;
        public bool? bargein;
        public int? minConfidence;
        public string name;
        public bool? required;
        public Say say;
        public float? timeout;
        public ArrayList to;
        public Endpoint from;
        public string network;
        public string channel;
        public bool? answerOnMedia;
        public Hashtable headers;
        public StartRecording recording;
        public string @value;
        public string mode = null;
        public string termChar = null;
        public string id;
        public bool? mute;
        public bool? playTones;
        public string terminator;
        public string voice;
        public string @event;
        public string next;
        public string format;
        public float? maxSilence;
        public float? maxTime;
        public string method;
        public string password;
        public Transcription transcription;
        public string username;
        public string url;
        public string @as;
        public string emailFormat;
        public On on;
        public int? ringRepeat;
        public bool? beep;
    }
}
