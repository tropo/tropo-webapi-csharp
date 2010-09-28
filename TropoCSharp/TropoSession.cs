using Newtonsoft.Json.Linq;

namespace TropoCSharp.Tropo
{
    /// <summary>
    /// Create an instance of the Tropo Session object.
    /// </summary>
    public class Session
    {
        private string _accountId;
        private Endpoint _from;
        private string _id;
        private string _initialText;
        private string _timestamp;
        private Endpoint _to;
        private string _userType;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="JSON">Session JSON submitted from Tropo platform.</param>
        public Session(string JSON)
        {
            JObject session = JObject.Parse(JSON);
            this._accountId = (string)session["session"]["accountId"];
            this._id = (string)session["session"]["id"];
            this._initialText = (string)session["session"]["initialText"];
            this._timestamp = (string)session["session"]["timestamp"];
            this._userType = (string)session["session"]["userType"];

            string from_id = (string)session["session"]["from"]["id"];
            string from_name = (string)session["session"]["from"]["name"];
            string from_network = (string)session["session"]["from"]["from"];
            string from_channel = (string)session["session"]["from"]["channel"];
            this._from = new Endpoint(from_id, from_channel, from_name, from_network);

            string to_id = (string)session["session"]["to"]["id"];
            string to_name = (string)session["session"]["to"]["name"];
            string to_network = (string)session["session"]["to"]["from"];
            string to_channel = (string)session["session"]["to"]["channel"];
            this._to = new Endpoint(to_id, to_channel, to_name, to_network);
        }

        /// <summary>
        /// Contains the user account ID that started this session.
        /// </summary>
        public string AccountId
        {
            get { return _accountId; }
            set { _accountId = value; }
        }

        /// <summary>
        /// Contains the elements that identify the origination of the session.
        /// </summary>
        public Endpoint From
        {
            get { return _from; }
            set { _from = value; }
        }

       /// <summary>
       /// Contains the GUID representing the unique session identifier.
       /// </summary>
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// When the channel is of a type "TEXT", this field contains the initial text of the message from the SMS 
        /// or instant message that the user sent when initiating the session.
        /// </summary>
        public string InitialText
        {
            get { return _initialText; }
            set { _initialText = value; }
        }

        /// <summary>
        /// The time that the session was started.
        /// </summary>
        public string Timestamp
        {
            get { return _timestamp; }
            set { _timestamp = value; }
        }

        /// <summary>
        /// The SIP destination for the incoming call.
        /// </summary>
        public Endpoint To
        {
            get { return _to; }
            set { _to = value; }
        }

        /// <summary>
        /// Identifies the type of user that is on the other end of the session; it can be set to 'HUMAN', 'MACHINE' or 'FAX'.
        /// </summary>
        public string UserType
        {
            get { return _userType; }
            set { _userType = value; }
        }
    }
}
