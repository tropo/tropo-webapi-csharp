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
        public const string MMS = "MMS";
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
        public const string UsEnglishFemale_Allison = "Allison";
        public const string UsEnglishFemale_Susan = "Susan";
        public const string UsEnglishFemale_Vanessa = "Vanessa";
        public const string UsEnglishFemale_Veronica = "Veronica";
        public const string UsEnglishMale_Dave = "Dave";
        public const string UsEnglishMale_Steven = "Steven";
        public const string UsEnglishMale_Victor = "Victor";
        public const string BritishEnglishFemale_Elizabeth = "Elizabeth";
        public const string BritishEnglishFemale_Kate = "Kate";
        public const string BritishEnglishMale = "Simon";
        public const string AustralianEnglishFemale = "Grace";
        public const string AustralianEnglishMale = "Alan";
        public const string CatalanFemale = "Montserrat";
        public const string CatalanMale = "Jordi";
        public const string DanishFemale = "Frida";
        public const string DanishMale = "Magnus";
        public const string DutchFemale = "Saskia";
        public const string DutchMale = "Willem";
        public const string FinnishFemale = "Milla";
        public const string FinnishMale = "Mikko";
        public const string FrenchFemale_Florence = "Florence";
        public const string FrenchFemale_Juliette = "Juliette";
        public const string FrenchMale = "Bernard";
        public const string FrenchCanadianFemale = "Charlotte";
        public const string FrenchCanadianMale = "Olivier";
        public const string GalacianFemale = "Carmela";
        public const string GermanFemale = "Katrin";
        public const string GermanMale = "Stefan";
        public const string GreekFemale = "Afroditi";
        public const string GreekMale = "Nikos";
        public const string ItalianFemale_Giulia = "Giulia";
        public const string ItalianFemale_Paola = "Paola";
        public const string ItalianFemale_Silvana = "Silvana";
        public const string ItalianFemale_Valentina = "Valentina";
        public const string ItalianMale_Luca = "Luca";
        public const string ItalianMale_Marcello = "Marcello";
        public const string ItalianMale_Matteo = "Matteo";
        public const string ItalianMale_Roberto = "Roberto";
        public const string ChineseMandarinMale_Linlin = "Linlin";
        public const string ChineseMandarinMale_Lisheng = "Lisheng";
        public const string NorwegianFemale = "Vilde";
        public const string NorwegianMale = "Henrik";
        public const string PolishFemale = "Zosia";
        public const string PolishMale = "Krzysztof";
        public const string RussianFemale = "Olga";
        public const string RussianMale = "Dmitri";
        public const string SpanishCastilianFemale_Carmen = "Carmen";
        public const string SpanishCastilianFemale_Leonor = "Leonor";
        public const string SpanishCastilianMale_Jorge = "Jorge";
        public const string SpanishCastilianMale_Juan = "Juan";
        public const string SpanishArgentineMale = "Diego";
        public const string SpanishChileanFemale = "Francisca";
        public const string SpanishMexicanFemale_Soledad = "Soledad";
        public const string SpanishMexicanFemale_Ximena = "Ximena";
        public const string SpanishMexicanFemale_Esperanza = "Esperanza";
        public const string SpanishMexicanMale_Carlos = "Carlos";
        public const string PortugeseFemale = "Amalia";
        public const string PortugeseMale = "Eusebio";
        public const string PortugeseBrazilianFemale_Fernanda = "Fernanda";
        public const string PortugeseBrazilianFemale_Gabriela = "Gabriela";
        public const string PortugeseBrazilianMale = "Felipe";
        public const string SwedishFemale = "Annika";
        public const string SwedishMale = "Sven";
        public const string ValencianMale = "Empar";

    }

    /// <summary>
    /// Speech recognizer options.
    /// </summary>
    public struct Recognizer
    {
        public const string UsEnglish = "en-us";
        public const string BritishEnglish =" en-bg";
        public const string Catalan = "ca-es";
        public const string Danish = "da-dk";
        public const string Dutch = "nl-nl";
        public const string Finnish = "fi-fi"; 
        public const string French = "fr-fr";
        public const string FrenchCanadian = "fr-ca";
        public const string Galacian = "gl-es";
        public const string German = "de-de";
        public const string Greek = "el-gr";
        public const string Italian = "it-it"; 
        public const string Polish = "pl-pl";
        public const string Russian = "ru-ru";
        public const string SpanishCastilian = "es-es";
        public const string SpanishArgentine = "es-ar";
        public const string SpanishChilean = "es-cl";
        public const string SpanishMexican = "es-mx";
        public const string Portugese = "pt-pt";
        public const string PortugeseBrazilian = "pt-br";
        public const string Swedish = "sv-se";
        public const string Valencian = "x-va";
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
