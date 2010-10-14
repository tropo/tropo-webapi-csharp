namespace TropoCSharp.Structs
{
    /// <summary>
    /// Date formats for Tropo TTS readback.
    /// </summary>
    public struct Date
    {
        public const string MonthDayYear = "mdy";
        public const string DayMonthYear = "dmy";
        public const string YearMonthDay = "ymd";
        public const string YearMonth = "ym";
        public const string MonthYear = "my";
        public const string MonthDay = "md";
        public const string Year = "y";
        public const string Month = "m";
        public const string Day = "d";
    }

    /// <summary>
    /// Duration formats for Tropo TTS readback.
    /// </summary>
    public struct Duration
    {
        public const string HoursMinutesSeconds = "hms";
        public const string HoursMinutes = "hm";
        public const string Hours = "h";
        public const string Minutes = "m";
        public const string Seconds = "s";
    }

    /// <summary>
    /// Event names for use with Tropo On object.
    /// </summary>
    public struct Event
    {
        public const string Continue = "continue";
        public const string Incomplete = "incomplete";
        public const string Error = "error";
        public const string Hangup = "hangup";
        public const string Join = "join";
        public const string Leave = "leave";
        public const string Ring = "ring";
    }

    /// <summary>
    /// Say as format for Tropo TTS readback.
    /// </summary>
    public struct SayAs
    {
        public const string Date = "DATE";
        public const string Digits = "DIGITS";
        public const string Number = "NUMBER";
    }

    /// <summary>
    /// Network values for use with Call, Message, etc.
    /// </summary>
    public struct Network
    {
        public const string Pstn = "PSTN";
        public const string Voip = "VOIP";
        public const string Aim = "AIM";
        public const string Gtalk = "GTALK";
        public const string Jabber = "JABBER";
        public const string Msn = "MSN";
        public const string SMS = "SMS";
        public const string Yahoo = "YAHOO";
        public const string Twitter = "TWITTER";
    }

    /// <summary>
    /// Channel values for use with Call, Message, etc. 
    /// </summary>
    public struct Channel
    {
        public const string Voice = "VOICE";
        public const string Text = "TEXT";
    }

    /// <summary>
    /// Audio format for recordings.
    /// </summary>
    public struct AudioFormat
    {
        public const string Wav = "audio/wav";
        public const string Mp3 = "audio/mp3";
    }

    /// <summary>
    /// TTS voice options.
    /// </summary>
    public struct Voice
    {
        public const string CastilianSpanishMale = "jorge";
        public const string CastilianSpanishFemale = "carmen";
        public const string FrenchMale = "bernard";
        public const string FrenchFemale = "florence";
        public const string UsEnglishMale = "dave";
        public const string UsEnglishFemale = "jill";
        public const string BritishEnglishMale = "dave";
        public const string BritishEnglishFemale = "kate";
        public const string GermanMale = "stefan";
        public const string GermanFemale = "katrin";
        public const string ItalianMale = "luca";
        public const string ItalianFemale = "paola";
        public const string DutchMale = "willem";
        public const string DutchFemale = "saskia";
        public const string MexicanSpanishMale = "carlos";
        public const string MexicanSpanishFemale = "soledad";
    }

    /// <summary>
    /// HTTP methods for posting recordings.
    /// </summary>
    public struct Method
    {
        public const string Post = "POST";
        public const string Put = "PUT";
    }
}
