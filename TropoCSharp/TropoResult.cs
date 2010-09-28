using Newtonsoft.Json.Linq;

namespace TropoCSharp.Tropo
{
    /// <summary>
    /// Create an instance of the Tropo Result object.
    /// </summary>
    public class Result
    {
        private string _sessionId;
        private string _state;
        private int _sessionDuration;
        private int _sequence;
        private bool _complete;
        private string _error;
        private JArray _actions;

        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="JSON">Result JSON submitted from Tropo platform.</param>
        public Result(string JSON)
        {
            JObject results = JObject.Parse(JSON);
            this._sessionId = (string)results["result"]["sessionId"];
            this._state = (string)results["result"]["state"];
            this._sessionDuration = (int)results["result"]["sessionDuration"];
            this._sequence = (int)results["result"]["sequence"];
            this._complete = (bool)results["result"]["complete"];
            this._error = (string)results["result"]["error"];
            this._actions = (JArray)results["result"]["actions"];
        }

        /// <summary>
        /// The state of the session at the time the result was generated.
        /// </summary>
        public string State
        {
            get { return _state; }
            set { _state = value; }
        }

        /// <summary>
        /// The unique identifier that is available with each session and result payload.
        /// </summary>
        public string SessionId
        {
            get { return _sessionId; }
            set { _sessionId = value; }
        }

        /// <summary>
        /// The total length of time, in seconds, the current session has been running.
        /// </summary>
        public int SessionDuration
        {
            get { return _sessionDuration; }
            set { _sessionDuration = value; }
        }

        /// <summary>
        /// Represents the number of Tropo payloads returned from your application.
        /// </summary>
        public int Sequence
        {
            get { return _sequence; }
            set { _sequence = value; }
        }

        /// <summary>
        /// Indicates whether a request resulted in all required fields being completed.
        /// </summary>
        public bool Complete
        {
            get { return _complete; }
            set { _complete = value; }
        }

        /// <summary>
        /// If the state of the result is an error, refer to this field for the error message.
        /// </summary>
        public string Error
        {
            get { return _error; }
            set { _error = value; }
        }

        /// <summary>
        /// The result of the actions requested in the previous payload.
        /// </summary>
        public JArray Actions
        {
            get { return _actions; }
            set { _actions = value; }
        }
    }
}
