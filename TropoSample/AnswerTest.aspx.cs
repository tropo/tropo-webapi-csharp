using System;
using System.Collections.Generic;
using System.Web.UI;
using TropoCSharp.Structs;
using TropoCSharp.Tropo;

namespace TropoSample
{
    /// <summary>
    /// A simple example demonstrating how to use the Ask method.
    /// </summary>
    public partial class AnswerTest : Page
    {
        public void Page_Load(object sender, EventArgs args)
        {
            // Create a new instance of the Tropo object.
            Tropo tropo = new Tropo();

            Say say1 = new Say("Are you frank on windows. thanks to jerry");

            IDictionary<string, string> headers = new Dictionary<String, String>();
            headers.Add("P-Header", "value goes here");
            headers.Add("Remote-Party-ID", "\"John Doe\"<sip:jdoe@foo.com>;party=calling;id-type=subscriber;privacy=full;screen=yes");

            //Answer answer = new Answer();
            //answer.Headers = headers;

            tropo.Answer(headers);
            tropo.Say(say1);
            tropo.RenderJSON(Response);
        }
    }
}
