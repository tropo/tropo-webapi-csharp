﻿using Newtonsoft.Json.Linq;

namespace TropoCSharp.Tropo
{
    /// <summary>
    /// Create an instance of the Tropo Result object
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="json">Result JSON submitted from Tropo platform</param>
        public Result(string json)
        {
            JObject results = JObject.Parse(json);
            SessionId = (string)results["result"]["sessionId"];
            State = (string)results["result"]["state"];
            SessionDuration = (int)results["result"]["sessionDuration"];
            Sequence = (int)results["result"]["sequence"];
            Complete = (bool)results["result"]["complete"];
            Error = (string)results["result"]["error"];
            JContainer container = (JContainer)results["result"]["actions"];
            if (container.Type == JTokenType.Array)
                Actions = (JArray)container;
            else
                Actions = new JArray(container);
        }

        /// <summary>
        /// The state of the session at the time the result was generated.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// The unique identifier that is available with each session and result payload.
        /// </summary>
        public string SessionId { get; set; }

        /// <summary>
        /// The total length of time, in seconds, the current session has been running.
        /// </summary>
        public int SessionDuration { get; set; }

        /// <summary>
        /// Represents the number of Tropo payloads returned from your application.
        /// </summary>
        public int Sequence { get; set; }

        /// <summary>
        /// Indicates whether a request resulted in all required fields being completed.
        /// </summary>
        public bool Complete { get; set; }

        /// <summary>
        /// If the state of the result is an error, refer to this field for the error message.
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// The result of the actions requested in the previous payload.
        /// </summary>
        public JArray Actions { get; set; }
    }
}
