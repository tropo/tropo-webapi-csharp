using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

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
        public static Result getResult(string json)
        {
            JObject results = JObject.Parse(json);
            JContainer resultJcontainer = (JContainer)results["result"];
            if (null != resultJcontainer["actions"])
            {
                JContainer ActionsObject = (JContainer)resultJcontainer["actions"];
                if (ActionsObject.Type == JTokenType.Array)
                {

                }
                else
                {

                    Action actionTemp = ActionsObject.ToObject<Action>();
                    List<Action> actionList = new List<Action>();
                    actionList.Add(actionTemp);

                    List<JToken> removeList = new List<JToken>();
                    foreach (JToken el in resultJcontainer.Children())
                    {
                        JProperty p = el as JProperty;
                        if (p != null && "actions".Equals(p.Name))
                        {
                            removeList.Add(el);
                            break;
                        }
                    }
                    foreach (JToken el in removeList)
                    {
                        el.Remove();
                    }
                    Result result = resultJcontainer.ToObject<Result>();
                    result.Actions = actionList;
                    return result;
                }
            }
            RootObject jobject = JsonConvert.DeserializeObject<RootObject>(json);
            return jobject.result;
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
        /// On outgoing calls (either with a call or transfer), the calledID will be set to the number called. In the case of multiple numbers called at once, calledID will indicate which number answered.
        /// </summary>
        public string CalledID { get; set; }

        /// <summary>
        /// This contains the ID of the call itself; this is not the caller ID or called ID, this is a value that identifies the actual call.
        /// </summary>
        public string CallId { get; set; }

        /// <summary>
        /// identify whether your call reached a live human or not
        /// </summary>
        public string userType { get; set; }

        /// <summary>
        /// The result of the actions requested in the previous payload.
        /// </summary>
        //public List<ActionResult> Actions { get; set; }
        public List<Action> Actions { get; set; }

    }


    public class Action
    {

        /// <summary>
        /// The name provided for this action result in the request.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The number of attempts it took to obtain the result.
        /// </summary>
        public int Attempts { get; set; }

        /// <summary>
        /// Set on a transfer only, the duration in seconds of a transferred call, starting from when the destination leg answers.
        /// </summary>
        public int ConnectedDuration { get; set; }

        /// <summary>
        /// Set on a transfer only, the total duration in seconds of a transferred call, including the time spent ringing before the call was answered.
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// The final result of the request, values may be SUCCESS, FAILED, EXTERNAL_EVENT, TIMEOUT, BUSY, or REJECTED.
        /// </summary>
        public string Disposition { get; set; }

        /// <summary>
        /// The result returned by the confidence engine that the result is correct.
        /// </summary>
        public int Confidence { get; set; }

        /// <summary>
        /// What the recognition engine believes what was said.
        /// </summary>
        public string Interpretation { get; set; }

        /// <summary>
        /// The specific utterance returned by the speech recognition engine.
        /// </summary>
        public string Utterance { get; set; }

        /// <summary>
        /// For speech recognition actions, this is the result of the grammar.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// The result of a Simple Grammar recognition. If you have a grammar that says "BBQ (BBQ, Bar Bee Que)" and someone says "Bar Bee Que", concept would be "BBQ".
        public string Concept { get; set; }

        /// <summary>
        /// Contains the raw NLSML output from the speech recognition engine. This is mostly useful when asking Tropo to troubleshoot recognition issues.
        /// </summary>
        public string Xml { get; set; }

        /// <summary>
        /// If the action is a Tropo "record" or a "stopCallRecording" this field will be present. 
        /// </summary>
        public string UploadStatus { get; set; }

        /// <summary>
        /// identify whether your call reached a live human or not
        /// </summary>
        public string userType { get; set; }


    }

    public class RootObject
    {
        public Result result { get; set; }
    }
}