using Newtonsoft.Json.Linq;
using System.Collections.Specialized;
using System;

namespace TropoCSharp.Tropo
{
    /// <summary>
    /// Create an instance of the Tropo Session object.
    /// </summary>
    public class Session
    {
        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="json">Session JSON submitted from Tropo platform.</param>
        public Session(string json)
        {
            JObject session = JObject.Parse(json);
            AccountId = (string)session["session"]["accountId"];
            CallId = (string)session["session"]["callId"];
            Id = (string)session["session"]["id"];
            InitialText = (string)session["session"]["initialText"];
            Timestamp = (string)session["session"]["timestamp"];
            UserType = (string)session["session"]["userType"];

            if (session["session"]["from"] != null)
            {
                string fromId = (string)session["session"]["from"]["id"];
                string fromName = (string)session["session"]["from"]["name"];
                string fromNetwork = (string)session["session"]["from"]["network"];
                string fromChannel = (string)session["session"]["from"]["channel"];
                string fromE164Id = (string)session["session"]["from"]["e164Id"];
                From = new Endpoint(fromId, fromE164Id, fromChannel, fromName, fromNetwork);
            }

            if (session["session"]["to"] != null)
            {
                string toId = (string)session["session"]["to"]["id"];
                string toName = (string)session["session"]["to"]["name"];
                string toNetwork = (string)session["session"]["to"]["network"];
                string toChannel = (string)session["session"]["to"]["channel"];
                string toE164Id = (string)session["session"]["to"]["e164Id"];
                To = new Endpoint(toId, toE164Id, toChannel, toName, toNetwork);
            }

            if (session["session"]["parameters"] != null)
            {
                Parameters = new NameValueCollection();
                JToken _parameter = session["session"]["parameters"].First;

                while (_parameter != null)
                {
                    JProperty property = (JProperty)_parameter;
                    Parameters.Add(property.Name, (String)property.Value);
                    _parameter = _parameter.Next;
                }
            }

            if (session["session"]["headers"] != null)
            {
                Headers = new NameValueCollection();
                JToken _header = session["session"]["headers"].First;

                while (_header != null)
                {
                    JProperty property = (JProperty)_header;
                    Headers.Add(property.Name, property.Value.ToString());
                    _header = _header.Next;
                }
            }

        }

        /// <summary>
        /// Contains the user account ID that started this session.
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// This contains the ID of the call itself; this is not the caller ID or called ID, this is a value that identifies the actual call.
        /// </summary>
        public string CallId { get; set; }

        /// <summary>
        /// Contains the elements that identify the origination of the session.
        /// </summary>
        public Endpoint From { get; set; }

        /// <summary>
        /// Contains the GUID representing the unique session identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// When the channel is of a type "TEXT", this field contains the initial text of the message from the SMS 
        /// or instant message that the user sent when initiating the session.
        /// </summary>
        public string InitialText { get; set; }

        /// <summary>
        /// The time that the session was started.
        /// </summary>
        public string Timestamp { get; set; }

        /// <summary>
        /// The SIP destination for the incoming call.
        /// </summary>
        public Endpoint To { get; set; }

        /// <summary>
        /// Identifies the type of user that is on the other end of the session; it can be set to 'HUMAN', 'MACHINE' or 'FAX'.
        /// </summary>
        public string UserType { get; set; }

        /// <summary> 
        /// Identifies the parameters passed in to the session. 
        /// </summary> 
        public NameValueCollection Parameters { get; set; }

        /// <summary> 
        /// Identifies the SIP headers passed in to the session. 
        /// </summary> 
        public NameValueCollection Headers { get; set; } 
    }
}
