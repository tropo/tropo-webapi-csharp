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
    public partial class TROPO12171 : Page
    {
        public void Page_Load(object sender, EventArgs args)
        {
            // Create a new instance of the Tropo object.
            Tropo tropo = new Tropo();

            Say say1 = new Say("test remote party id 3");

            IDictionary<string, string> headers = new Dictionary<String, String>();
            //headers.Add("P-Header", "TROPO12171value goes here");
            headers.Add("Remote-Party-ID", "\"John Doe\"<sip:jdoe@foo.com>TROPO12171ab;party=calling;id-type=subscriber;privacy=full;screen=yes");
            //headers.Add("Remote-Party-ID", "\\yigegang3");

            //Answer answer = new Answer();
            //answer.Headers = headers;

            tropo.Answer(headers);
            tropo.Say(say1);
            tropo.RenderJSON(Response);
        }
    }
}
