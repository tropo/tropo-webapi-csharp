namespace TropoCSharp.Structs
{
    /// <summary>
    /// Date formats for Tropo TTS readback.
    /// </summary>
    public struct Date
    {
        public static string monthDayYear = "mdy";
        public static string dayMonthYear = "dmy";
        public static string yearMonthDay = "ymd";
        public static string yearMonth = "ym";
        public static string monthYear = "my";
        public static string monthDay = "md";
        public static string year = "y";
        public static string month = "m";
        public static string day = "d"; 
    }

    /// <summary>
    /// Duration formats for Tropo TTS readback.
    /// </summary>
    public struct Duration
    {
        public static string hoursMinutesSeconds = "hms";
        public static string hoursMinutes = "hm";
        public static string hours = "h";
        public static string minutes = "m";
        public static string seconds = "s";
    }

    /// <summary>
    /// Event names for use with Tropo On object.
    /// </summary>
    public struct Event
    {
        public static string @continue = "continue";
        public static string incomplete = "incomplete";
        public static string error = "error";
        public static string hangup = "hangup";
        public static string join = "join";
        public static string leave = "leave";
        public static string ring = "ring";
    }

    /// <summary>
    /// Say as format for Tropo TTS readback.
    /// </summary>
    public struct SayAs
    {
        public static string date = "DATE";
        public static string digits = "DIGITS";
        public static string number = "NUMBER";
    }

    /// <summary>
    /// Network values for use with Call, Message, etc.
    /// </summary>
    public struct Network
    {
        public static string pstn = "PSTN";
        public static string voip = "VOIP";
        public static string aim = "AIM";
        public static string gtalk = "GTALK";
        public static string jabber = "JABBER";
        public static string msn = "MSN";
        public static string sms = "SMS";
        public static string yahoo = "YAHOO";
        public static string twitter = "TWITTER";
    }
    
    /// <summary>
    /// Channel values for use with Call, Message, etc. 
    /// </summary>
    public struct Channel
    {
        public static string voice = "VOICE";
        public static string text = "TEXT";
    }

    /// <summary>
    /// Audio format for recordings.
    /// </summary>
    public struct AudioFormat
    {
        public static string wav = "audio/wav";
        public static string mp3 = "audio/mp3";
    }

    /// <summary>
    /// TTS voice options.
    /// </summary>
    public struct Voice
    {
        public static string Castilian_Spanish_male = "jorge";
        public static string Castilian_Spanish_female = "carmen";
        public static string French_male = "bernard";
        public static string French_female = "florence";
        public static string US_English_male = "dave";
        public static string US_English_female = "jill";
        public static string British_English_male = "dave";
        public static string British_English_female = "kate";
        public static string German_male = "stefan";
        public static string German_female = "katrin";
        public static string Italian_male = "luca";
        public static string Italian_female = "paola";
        public static string Dutch_male = "willem";
        public static string Dutch_female = "saskia";
        public static string Mexican_Spanish_male = "carlos";
        public static string Mexican_Spanish_female = "soledad";
    }

    /// <summary>
    /// HTTP methods for posting recordings.
    /// </summary>
    public struct Method
    {
        public static string post = "POST";
        public static string put = "PUT";
    }
}
